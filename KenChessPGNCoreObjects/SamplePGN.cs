using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChessPGNCoreObjects
{
    public static class SamplePGN
    {
        public const string SampleGame1 = "[Event \"Max Lange Attack\"]\r\n"
            + "[Site \"This is a tutorial to teach Max Lange Attack\"]\r\n[Date \"2023.05.07\"]\r\n"
            + "[Round \"?\"]\r\n[White \"Player1\"]\r\n[Black \"Player2\"]\r\n[Result \"*\"]\r\n"
            + "[Annotator \"Smith,Ken\"]\r\n[PlyCount \"29\"]\r\n\r\n"
            + "1. e4 e5 2. Nf3 Nc6 3. Bc4 Bc5 4. d4 $5 {Max Lange Attack} exd4 (4... Bxd4 5.\r\n"
            + "Bg5 Nf6 (5... f6 6. Nxd4 Nxd4 7. Be3 Ne7 8. O-O) 6. Nxd4 Nxd4 7. f4 d6 8. f5)\r\n"
            + "5. O-O Nf6 6. e5 d5 $1 (6... Ng4 $2 7. Bxf7+ Kxf7 8. Ng5+ Kg8 9. Qxg4 Nxe5 10.\r\n"
            + "Qe4 d6 11. Qd5+ Kf8 12. f4 $1) 7. exf6 dxc4 8. Re1+ Be6  9. Ng5 {Black has only\r\n"
            + "one saving move!} Qd5 $1 (9... Qxf6 $2 10. Nxe6 fxe6 11. Qh5+ g6 12. Qxc5 $1\r\n"
            + "{White wins a bishop.}) (9... O-O $2 10. fxg7 Kxg7 (10... Re8 11. Qh5 Bf5 $4\r\n"
            + "12. Qxf7#) 11. Rxe6 $1 h6 $2 12. Rxh6 $1 {Black loses Queen if king captures\r\n"
            + "rook.}) 10. Nc3 $1 Qf5 11. Nce4 O-O-O (11... gxf6 $2 12. g4 $1 Qd5 13. Nxe6\r\n"
            + "fxe6 14. Bh6) 12. g4 $1 Qe5 13. fxg7 Rhg8 14. Nxe6 fxe6 15. Bh6 *\r\n\r\n";
        
        public const string SampleMultiGamePGN = "[Event \"Pittsburgh op\"]\r\n[Site \"Pittsburgh\"]\r\n[Date \"1946.??.??\"]\r\n"
            + "[Round \"?\"]\r\n[White \"Aleman Dovo, Miguel \"]\r\n[Black \"Berliner, Hans Jack\"]\r\n[Result \"1-0\"]\r\n\r\n"
            + "1.e4 e6 2.d4 d5 3.Nc3 Nf6 4.Bg5 dxe4 5.Nxe4 Nbd7 6.Nf3 Be7 7.Nxf6+ Nxf6 8.Bd3 b6\r\n"
            + "9.Qe2 Bb7 10.O-O O-O 11.Rad1 Qd5 12.c4 Qa5 13.Ne5 Rad8 14.a3 c5 15.d5 exd5\r\n"
            + "16.Ng4 Nxg4 17.Bxe7 Rde8 18.Qxg4 Rxe7 19.Bxh7+ Kh8 20.Qh4 Re6 21.Bg6+  1-0\r\n\r\n"
            + SampleGame1;
    }
}
