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

            //�����Ȃ����Ă��Ȃ��Ƃ���Pin���͂�0V�ɂȂ�悤�ɂ��邽��PullDown���܂��B
            GpioPin buttonPin = controller.OpenPin(35, PinMode.InputPullDown);

            while (true)
            {
                //�X�C�b�`�̏�Ԃ��m�F
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
