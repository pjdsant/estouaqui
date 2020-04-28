/*
 * Desenvolvido por Paulo Santos.
 * 15/04/2020
 * Programa manter a tela de descanso desativada
 * 
 */

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace EstouAqui
{
    class Program
    {
        public const uint ES_CONTINUOUS = 0x80000000;
        public const uint ES_SYSTEM_REQUIRED = 0x00000001;
        public const uint ES_DISPLAY_REQUIRED = 0x00000002;

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern uint SetThreadExecutionState([In] uint esFlags);

        //[DllImport("User32.dll", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //private static extern bool ShowWindow([In] IntPtr hWnd, [In] int nCmdShow);

        static void Main(string[] args)
        {

            string userName = "";

            try
            {
                userName  = Environment.UserName;
            }
            catch (Exception)
            {
                userName = "meu amigo";
            }

            try
            {
               
                SetThreadExecutionState(ES_CONTINUOUS | ES_DISPLAY_REQUIRED);

                Console.WriteLine("Olá {0}, estou aqui para manter sua Tela de Descanso Desativada!!!", userName);
                Console.WriteLine("Mas se desejar pode me desligar, para isso basta teclar 'Enter' 2 vezes!");
               
                //IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;

                //ShowWindow(handle, 6);

                Console.ReadLine();

                SetThreadExecutionState(ES_CONTINUOUS);
                Console.WriteLine("Encerrando...");
                Thread.Sleep(2000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Algo deu errado e não pode desativar a sua Tela de Descanso!");
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Mensagem de erro do sistema: ");
                Console.WriteLine(ex.Message.ToString());
                Console.WriteLine("--------------------------------------------------------------");
                Console.WriteLine("Verifique com o Admin do sistema se seu usuário tem alguma restrição para executar esse aplicativo!");
                Console.WriteLine("Tecler Enter para me encerrar");
                Console.WriteLine("Encerrando...");

                Thread.Sleep(2000);
            }
            
        }


    }
}
