using System;
using System.Management;

namespace USBDeviceWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Monitorowanie podłączenia urządzenia USB...");

            ManagementEventWatcher watcher = new ManagementEventWatcher();
            watcher.Query = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");

            watcher.EventArrived += Watcher_EventArrived;

            watcher.Start();

            Console.WriteLine("Naciśnij dowolny klawisz, aby zakończyć.");
            Console.ReadKey();

            watcher.Stop();

            Console.ReadKey();
        }

        private static void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            Console.WriteLine("Urządzenie USB zostało podłączone!");
        }
    }
}