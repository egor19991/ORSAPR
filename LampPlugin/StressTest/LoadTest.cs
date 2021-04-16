using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelBuilder;
using ModelParameters;
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace StressTest
{
    /// <summary>
    /// Класс для стресс-теста плагина
    /// </summary>
    public class LoadTest
    {
        /// <summary>
        /// Струкьтура для хранения данных о количестве занятой ОЗУ и времени выполнения плагина
        /// </summary>
        public struct TestingParametetr
        {
            public string elapsedTime;
            public long WorkingSet64;
        }

        /// <summary>
        /// массив с данным о тестировании
        /// </summary>
        private LoadTest.TestingParametetr[] testingParameters = new LoadTest.TestingParametetr[201];

        /// <summary>
        /// метод для запуска тестирования
        /// </summary>
        public void RunTest()
        {
            LampParameters lamp = new LampParameters();
            LampBuilder build = new LampBuilder();
            Stopwatch stopWatch = new Stopwatch();
            lamp.DefaultValue();

            for (int i = 1; i <= 197; i++)
            {
                stopWatch.Start();
                //Thread.Sleep(10000);
                Console.WriteLine($"Итерация {i}");
                build.BuildLamp(lamp);
                stopWatch.Stop();
                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                LoadMemory(elapsedTime, i);
                stopWatch.Reset();
            }
             
            ExportData();
        }

        /// <summary>
        /// Метод для отображения занятой ОЗУ и добавление в массив времени выполнения процесса
        /// </summary>
        /// <param name="elapsedTime"></param>
        /// <param name="index"></param>
        public void LoadMemory(string elapsedTime, int index)
        {
            // Start the process.
            Process[] myProcess1 = Process.GetProcessesByName("kStudy");

            Process myProcess = myProcess1[myProcess1.Length - 1];

            // Display the process statistics until
            // the user closes the program.

            if (!myProcess.HasExited)
            {
                // Refresh the current process property values.
                myProcess.Refresh();

                Console.WriteLine();

                // Display current process statistics.

                Console.WriteLine($"{myProcess} -");
                Console.WriteLine("-------------------------------------");

                Console.WriteLine($"  Physical memory usage     : {myProcess.WorkingSet64 / 1024}");
                Console.WriteLine($"  Base priority             : {myProcess.BasePriority}");
                Console.WriteLine($"  Priority class            : {myProcess.PriorityClass}");
                Console.WriteLine($"  User processor time       : {myProcess.UserProcessorTime}");
                Console.WriteLine($"  Privileged processor time : {myProcess.PrivilegedProcessorTime}");
                Console.WriteLine($"  Total processor time      : {myProcess.TotalProcessorTime}");
                Console.WriteLine($"  Paged system memory size  : {myProcess.PagedSystemMemorySize64}");
                Console.WriteLine($"  Paged memory size         : {myProcess.PagedMemorySize64}");
                Console.WriteLine("RunTime " + elapsedTime);

                if (myProcess.Responding)
                {
                    Console.WriteLine("Status = Running");
                }
                else
                {
                    Console.WriteLine("Status = Not Responding");
                }

                testingParameters[index].elapsedTime = elapsedTime;
                testingParameters[index].WorkingSet64 = myProcess.WorkingSet64 / 1024;
            }
        }

        /// <summary>
        /// Метод для экспорта данных в Excel
        /// </summary>
        public void ExportData()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var file = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/MyWorkbook.xlsx");

            using (var package = new ExcelPackage(file))
            {
                
                var workSheet = package.Workbook.Worksheets.Add("TestingParameterSheet");
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;
                //Header of table  
                
                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;
                workSheet.Cells[1, 1].Value = "Working Time";
                workSheet.Cells[1, 2].Value = "Memory";

                //Body of table  
                int recordIndex = 2;
                foreach (var testingParameter in testingParameters)
                {
                    workSheet.Cells[recordIndex, 1].Value = testingParameter.elapsedTime;
                    workSheet.Cells[recordIndex, 2].Value = testingParameter.WorkingSet64;
                    recordIndex++;
                }

                workSheet.Column(1).AutoFit();
                workSheet.Column(2).AutoFit();

                package.Save();
            }
        }

    }
}
