using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace IdentificationComp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список всех MAC адресов сетевых устройств:");
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            string sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                IPInterfaceProperties properties = adapter.GetIPProperties();
                sMacAddress = adapter.GetPhysicalAddress().ToString();
                Console.WriteLine($"{adapter.Name} \t\t {adapter.Description} \t {adapter.NetworkInterfaceType} MAC - {sMacAddress}");
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Операционная система:");
            OperatingSystem os_info = System.Environment.OSVersion;
            Console.WriteLine($"OS Version:\t\t{os_info.VersionString}");
            Console.WriteLine($"ServicePack:\t\t{os_info.ServicePack}");
            Console.WriteLine($"Version:\t\t{os_info.Version}");
            Console.WriteLine($"Platform:\t\t{os_info.Platform}");

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Пользователь:\t\t{Environment.UserName}");

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Список логических дисков:");
            foreach (string logicDr in Environment.GetLogicalDrives())
            {
                Console.WriteLine(logicDr);
            }

            Console.WriteLine("--------------------------------");
            Console.WriteLine($"MachineName:\t\t\t{Environment.MachineName}");
            Console.WriteLine($"ProcessorCount:\t\t\t{Environment.ProcessorCount}");
            Console.WriteLine($"SystemDirectory:\t\t{Environment.SystemDirectory}");
            Console.WriteLine($"Время с момента загрузки\t{Environment.TickCount}ms");
            Console.WriteLine($"UserDomainName:\t\t\t{Environment.UserDomainName}");
            Console.WriteLine($"UserInteractive:\t\t{Environment.UserInteractive}");

            Console.WriteLine("--------------------------------");

            SelectQuery query = new SelectQuery("SELECT SerialNumber FROM Win32_BaseBoard");
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (var board in searcher.Get())
                {
                    foreach (var property in board.Properties)
                        Console.WriteLine($"{0} = {1}", property.Name, property.Value);
                }
            }

            Console.WriteLine("End.");
            Console.ReadKey();

        }
    }
}