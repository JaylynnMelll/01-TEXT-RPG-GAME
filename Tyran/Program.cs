using System.Text;
using Tyran.GameLogic;
using Tyran.Character;
using Tyran.Utilities;

namespace Tyran
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 한글 인코딩 정상화
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // 00) 게임 인트로
            GameManager.Intro();

            // 01) 게임 시작 & 플레이어 생성
            Player player = GameManager.CreatePlayer();
            PlayerManager.Initialize(player);

            // 02) 하멜 게임 메인 화면
            GameManager.HamelMain();             
        }
    }
}
