using System;
using System.Device.Gpio;
using System.Threading;

namespace ESP32S3_Button
{
    public class Program
    {
        public static void Main()
        {
            GpioController controller=new GpioController();

            GpioPin ledPin=controller.OpenPin(2,PinMode.Output);

            //何もつながっていないときはPin入力が0VになるようにするためPullDownします。
            GpioPin buttonPin = controller.OpenPin(35, PinMode.InputPullDown);

            while (true)
            {
                //スイッチの状態を確認
                //Console.WriteLine(buttonPin.Read().ToString());

                
                if (buttonPin.Read() == PinValue.High)
                {
                    ledPin.Write(PinValue.High);
                }
                else
                {
                    ledPin.Write(PinValue.Low);
                }

                Thread.Sleep(50);
            }
        }
    }
}
