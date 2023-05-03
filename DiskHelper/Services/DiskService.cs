using System.Text;

namespace DiskHelper.Services
{
    public class DiskService: IDiskService
    {

        private const double ONE_10MB_FILE_TIMES = (1024 * 1024 * 10) / 32;
        
        public DiskService()
        {
            
        }

        /// <summary>
        /// Do Disk coverring.
        /// </summary>
        /// <param name="volume">Hard Disk Volumn ID, Like C, D, E</param>
        /// <param name="minLeftSpaceInGB"></param>
        /// <returns></returns>
        public Task DoJob(string volume, int minLeftSpaceInGB = 100)
        {
            long startTime = DiskHelper.GetTimeStamp(true);

            double freeSpaceInGB = DiskHelper.GetHardDiskSpaceInGB(volume);
            freeSpaceInGB = freeSpaceInGB - minLeftSpaceInGB;

            string defaultPath = volume + ":\\RadomData";
            if (!Directory.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }

            int maxParallelOpt = 10;
            int maxLoopTimes = (int)((freeSpaceInGB * 1024) / 10);

            ParallelOptions opt = new ParallelOptions()
            {
                MaxDegreeOfParallelism = maxParallelOpt
            };

            Parallel.For(0, maxLoopTimes, opt, item =>
            {
                
                DiskHelper.WriteRandomFile(defaultPath, ONE_10MB_FILE_TIMES, volume, minLeftSpaceInGB);
               
            });

            var stopTime = DiskHelper.GetTimeStamp(true);
            Console.WriteLine($"Job cost: {(stopTime - startTime) / 1000}");

            return Task.CompletedTask;
        }
    }

    public interface IDiskService
    {
        Task DoJob(string volume, int minSpaceLeft = 100);
    }

    public static class DiskHelper
    {
        /// <summary>
        /// 单位GB
        /// </summary>
        /// <param name="str_HardDiskName"></param>
        /// <returns></returns>
        public static double GetHardDiskSpaceInGB(string str_HardDiskName)
        {
            double totalSize = 0;
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }

        public static void WriteRandomFile(string defaultPath, double oneFileSize, string volume, int minLeftSpaceInGB)
        {
            var freeSpaceInGB = DiskHelper.GetHardDiskSpaceInGB(volume);
            if (freeSpaceInGB < minLeftSpaceInGB)
            {
                return;
            }
            Random rd = new Random();
            
            string fileName = $"{defaultPath}\\{DiskHelper.GetTimeStamp(true)}-{rd.Next(10,1000)}";

            while (File.Exists(fileName))
            {
                fileName = $"{defaultPath}\\{DiskHelper.GetTimeStamp(true)}-{rd.Next(10, 1000)}";
            }

            using (StreamWriter file = new StreamWriter(fileName, true))
            {
                StringBuilder randomData = new StringBuilder();

                for (int i = 0; i < oneFileSize; i++)
                {
                    randomData.Append(Guid.NewGuid().ToString("N"));
                }

                file.Write(randomData.ToString());
            }

            Console.WriteLine($"File {fileName} done.");
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="isMillisecond">是否毫秒</param>
        /// <returns>当前时间戳</returns>
        public static long GetTimeStamp(bool isMillisecond = false)
        {
            var ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            var timeStamp = isMillisecond ? Convert.ToInt64(ts.TotalMilliseconds) : Convert.ToInt64(ts.TotalSeconds); return timeStamp;
        }
    }
}
