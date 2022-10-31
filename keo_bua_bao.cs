string arbitration;
int player;
int bot;
char tieptuc = ' ';
do
{
    Console.OutputEncoding =System.Text.Encoding.UTF8;
    Console.WriteLine("^^^^^^^^^^^^^^^^^^^^^");
    Console.WriteLine("<    Kéo Búa Bao    >");
    Console.WriteLine("---------------------");
    Console.WriteLine("VUI LÒNG LÀM THEO HƯỚNG DẪN");
    Console.WriteLine("1 kéo, 2 búa, 3 bao");
    Console.WriteLine("player vs bot");

    arbitration = Console.ReadLine();
    Random rd = new Random();
    bot = rd.Next(1, 4);
    if (int.TryParse(arbitration, out player) == false || player < 1 || player > 3)
    {
        Console.WriteLine("dữ liệu nhập sai");
        break;
    }
    else
    {
        if (player == 1)
        {
            if (bot == 1)
            {
                Console.WriteLine("lựa chọn của bạn là: kéo");
                Console.WriteLine("lựa chọn của bạn là: kéo");
                Console.WriteLine("HÒA: kéo = kéo");
            }
            else if (bot == 2)
            {
                Console.WriteLine("lựa chọn của bạn là: kéo");
                Console.WriteLine("lựa chọn của bạn là: búa");
                Console.WriteLine("PLAYER THUA BOT: kéo < búa");
            }
            else if (bot == 3)
            {
                Console.WriteLine("lựa chọn của bạn là: kéo");
                Console.WriteLine("lựa chọn của bạn là: bao");
                Console.WriteLine("PLAYER THẮNG BOT: kéo > bao");
            }
        }

        else if (player == 2) ;

        if (bot == 1)
        {
            Console.WriteLine("lựa chọn của bạn là: búa");
            Console.WriteLine("lựa chọn của bạn là: kéo");
            Console.WriteLine("PLAYER THẮNG BOT: búa > kéo");
        }
        else if (bot == 2)
        {
            Console.WriteLine("lựa chọn của bạn là: búa");
            Console.WriteLine("lựa chọn của bạn là: búa");
            Console.WriteLine("HÒA: búa = búa");
        }
        else if (bot == 3)
        {
            Console.WriteLine("lựa chọn của bạn là: búa");
            Console.WriteLine("lựa chọn của bạn là: bao");
            Console.WriteLine("PLAYER THUA BOT: búa < bao");
        }
        else if (player == 3)
        {
            if (bot == 1)
            {
                Console.WriteLine("lựa chọn của bạn là: bao");
                Console.WriteLine("lựa chọn của bạn là: kéo");
                Console.WriteLine("PLAYER THUA BOT: bao < kéo");
            }
            else if (bot == 2)
            {
                Console.WriteLine("lựa chọn của bạn là: bao");
                Console.WriteLine("lựa chọn của bạn là: búa");
                Console.WriteLine("PLAYER THẮNG BOT: bao > búa");
            }
            else if (bot == 3)
            {
                Console.WriteLine("lựa chọn của bạn là: bao");
                Console.WriteLine("lựa chọn của bạn là: bao");
                Console.WriteLine("HÒA: bao = bao");
            }

        }

    }
    Console.Write("Do you want to play again? (Y/N): ");
    char.TryParse(Console.ReadLine(), out tieptuc);
    if (tieptuc == 'N')
    {
        Console.WriteLine("see you again");
        break;
    }
} while (tieptuc == 'Y' || tieptuc == 'N');
Console.ReadKey();