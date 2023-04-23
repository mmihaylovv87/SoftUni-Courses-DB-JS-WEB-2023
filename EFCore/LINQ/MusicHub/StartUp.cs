namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context = new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //string result = ExportAlbumsInfo(context, 9)
            string result = ExportSongsAboveDuration(context, 4);

            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder sb = new StringBuilder();

            var albumsInfo = context.Albums
                .ToArray()
                .Where(a => a.ProducerId == producerId)
                .OrderByDescending(a => a.Price)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .ToArray()
                        .Select(s => new
                        {
                            SongName = s.Name,
                            Price = s.Price.ToString("f2"),
                            Writer = s.Writer.Name,
                        })
                        .OrderByDescending(s => s.SongName)
                        .ThenBy(s => s.Writer)
                        .ToArray(),
                    TotalAlbumPrice = a.Price.ToString("f2")
                })
                .ToArray();

            foreach (var albumInfo in albumsInfo)
            {
                sb.AppendLine($"-AlbumName: {albumInfo.AlbumName}")
                  .AppendLine($"-ReleaseDate: {albumInfo.ReleaseDate}")
                  .AppendLine($"-ProducerName: {albumInfo.ProducerName}")
                  .AppendLine($"-Songs:");

                int i = 0;
                foreach (var song in albumInfo.Songs)
                {
                    sb.AppendLine($"---#{++i}")
                      .AppendLine($"---SongName: {song.SongName}")
                      .AppendLine($"---Price: {song.Price}")
                      .AppendLine($"---Writer: {song.Writer}");
                }

                sb.AppendLine($"-AlbumPrice: {albumInfo.TotalAlbumPrice}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();

            var songs = context.Songs
                .ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PerformerName = s.SongPerformers
                        .ToArray()
                        .Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}")
                        .FirstOrDefault(),
                    WriterName = s.Writer.Name,
                    AlbumProducerName = s.Album.Producer.Name,
                    SongDuration = s.Duration.ToString("c", CultureInfo.InvariantCulture),
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToArray();

            int i = 0;
            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{++i}")
                  .AppendLine($"---SongName: {song.SongName}")
                  .AppendLine($"---Writer: {song.WriterName}")
                  .AppendLine($"---Performer: {song.PerformerName}")
                  .AppendLine($"---AlbumProducer: {song.AlbumProducerName}")
                  .AppendLine($"---Duration: {song.SongDuration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}