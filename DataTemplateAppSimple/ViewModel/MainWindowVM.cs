using DataTemplateAppSimple.Editors;
using DataTemplateAppSimple.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataTemplateAppSimple.ViewModel
{
    public class MainWindowVM : BaseVM
    {
        public ObservableCollection<object> Items { get; set; } = new();
        public CommandVM AddCPU { get; set; }
        private CPU newCPU;
        public CPU NewCPU
        {
            get => newCPU;
            set
            {
                newCPU = value;
                Signal();
            }
        }

        public CommandVM AddGPU { get; set; }
        private GPU newGPU;
        public GPU NewGPU
        {
            get => newGPU;
            set
            {
                newGPU = value;
                Signal();
            }
        }

        public CommandVM AddRAM { get; set; }
        private CPU newRAM;
        public CPU NewRAM
        {
            get => newRAM;
            set
            {
                newRAM = value;
                Signal();
            }
        }

        public MainWindowVM()
        {
            Items.Add(new CPU
            {
                Brand = "AMD",
                Clock_frequency = 2.4F,
                Price = 4000
            });
            AddCPU = new CommandVM(() =>
            {
                CPUAdd cpuwindow = new CPUAdd();
                cpuwindow.ShowDialog();
                Items.Add(cpuwindow.NewCPU);
                NewCPU = new CPU();
                Items = new();
                NewCPU = new CPU();
            });

            AddGPU = new CommandVM(() =>
            {
                GPUAdd cpuwindow = new GPUAdd();
                cpuwindow.ShowDialog();
                Items.Add(cpuwindow.NewGPU);
                NewGPU = new GPU();
                Items = new();
                NewGPU = new GPU();
            });


        }

        

        private void GPUAdd_Click(object sender, RoutedEventArgs e)
        {
            GPUAdd gpuWindow = new GPUAdd();
            gpuWindow.ShowDialog();
            Items.Add(gpuWindow.NewGPU);
        }

        private void RAMAdd_Click(object sender, RoutedEventArgs e)
        {
            RAMAdd ramWindow = new RAMAdd();
            ramWindow.ShowDialog();
            Items.Add(ramWindow.NewRAM);
        }
    }
}
