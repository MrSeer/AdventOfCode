using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class Puzzle2016_Day2:Puzzle
    {
        string input = @"DLUUULUDLRDDLLLUDULLULLRUURURLUULDUUUDLDDRUDLUULLRLDDURURDDRDRDLDURRURDLDUURULDDULDRDDLDLDLRDRUURLDLUDDDURULRLLLLRLULLUDRDLDUURDURULULULRLULLLULURLRDRDDDDDDDLRLULUULLULURLLDLRLUDULLDLLURUDDLDULDLULDDRLRLRDDLRURLLLURRLDURRDLLUUUUDRURUULRLDRRULLRUDLDRLUDRDRDRRDDURURRDRDRUDURDLUDRUDLRRULDLRDDRURDDUUDLDRDULDDRRURLLULRDRURLRLDLLLUULUUDLUDLDRRRRDUURULDUDUDRLDLLULLLRDDDDDLRDDLLUULLRRRDURLRURDURURLUDRRLRURDRDRRRRULUDLDRDULULRUDULLLUDRRLRLURDDURULDUUDULLURUULRDRDULRUUUDURURDDRRUDURRLRDRULRUUU
LDRURRUUUULDRDDDLLULDRUDDRLLDLDRDLRUDDDLDDULULULLRULDUDRRDLRUURURDRURURDLLRUURDUUDRLDURDRDLRRURURDUUUURUURRLLLDRDUURRRRURULUUUDLUDDRUURRLDULRDULRRRRUDURRLURULRURRDRDLLDRRDUDRDURLDDRURULDRURUDDURDLLLUURRLDRULLURDRDRLDRRURRLRRRDDDDLUDLUDLLDURDURRDUDDLUDLRULRRRDRDDLUDRDURDRDDUURDULRRULDLDLLUDRDDUDUULUDURDRLDURLRRDLDDLURUDRLDUURLLRLUDLLRLDDUDLLLRRRLDLUULLUDRUUDRLDUUUDUURLRDDDDRRDRLDDRDLUDRULDDDRDUULLUUUUULDULRLLLRLLDULRDUDDRDDLRRLRDDULLDURRRURDDUDUDDRLURRLUUUULLDRDULUUDRDULDLLUDLURDLLURRDLUULURRULRLURRRRRUURDDURLRLLDDLRRDUUURDRDUDRDDDLLDDRDRRRLURRDUULULULULRRURDDLDDLLLRUDDDDDDLLLRDULURULLRLRDRR
DDRLLLDLRRURRDLDDRUURRURRLRRRRUURUURDLURRRDDLRUDRURLUURLLRRLRLURLURURDULLLLDLRURULUUDURRLULRDRDRRDDLLULRLUDLUUUDRLLRRURRLDULDDLRRLUUUUDDLRLDRLRRDRDLDDURDDRDDLDLURLRRRDDUDLLRLRLURRRRULLULLLLDRLDULDLLDULRLDRDLDDRRDDDDRUDRLLURULRLDDLLRRURURDDRLLLULLULDDRDLDDDLRLLDRLDRUURRULURDDRLULLDUURRULURUUDULLRUDDRRLLDLLRDRUDDDDLLLDDDLLUUUULLDUUURULRUUDUUUDDLDURLDRDRRLLUDULDLUDRLLLDRRRULUUDDURUDRLUDDRRLLDUDUURDDRURLUURDURURURRUUDUDDLLLDRRRURURRURDLRULLDUDRLRLLRUDRUDLR
RRRDRLRURLRRLUURDRLDUURURLRDRRUDLLUUDURULLUURDLLDRRLURRUDUUDRRURLRRDULLDDLRRRUDUUDUUDLDDDLUUDLDULDDULLDUUUUDDUUDUDULLDDURRDLRRUDUDLRDUULDULRURRRLDLLURUDLDDDRRLRDURDLRRLLLRUDLUDRLLLRLLRRURUDLUDURLDRLRUDLRUULDRULLRLDRDRRLDDDURRRUDDDUDRRDRLDDRDRLLRLLRDLRDUDURURRLLULRDRLRDDRUULRDDRLULDLULURDLRUDRRDDDLDULULRDDRUDRLRDDRLDRDDRRRDUURDRLLDDUULRLLLULLDRDUDRRLUUURLDULUUURULLRLUDLDDLRRDLLRDDLRDRUUDURDDLLLDUUULUUDLULDUDULDRLRUDDURLDDRRRDLURRLLRRRUDDLDDRURDUULRUURDRRURURRRUUDUDULUDLUDLLLUUUULRLLRRRRDUDRRDRUDURLUDDLDRDLDDRULLRRULDURUL
DLLLRDDURDULRRLULURRDULDLUDLURDDURRLLRRLLULRDLDRDULRLLRDRUUULURRRLLRLDDDRDRRULDRRLLLLDLUULRRRURDDRULLULDDDLULRLRRRUDRURULUDDRULDUDRLDRRLURULRUULLLRUURDURLLULUURUULUUDLUDLRRULLLRRLRURDRRURDRULRURRUDUDDDRDDULDLURUDRDURLDLDLUDURLLRUULLURLDDDURDULRLUUUDLLRRLLUURRDUUDUUDUURURDRRRRRRRRRUDULDLULURUDUURDDULDUDDRDDRDRLRUUUUDLDLRDUURRLRUUDDDDURLRRULURDUUDLUUDUUURUUDRURDRDDDDULRLLRURLRLRDDLRUULLULULRRURURDDUULRDRRDRDLRDRRLDUDDULLDRUDDRRRD";

        int m_columnIndex = 0;
        int m_lineIndex = 2;

        char[,] pad = new char[5,5];

        public Puzzle2016_Day2()
        {
            pad[0, 0] = '0';
            pad[0, 1] = '0';
            pad[0, 2] = '1';
            pad[0, 3] = '0';
            pad[0, 4] = '0';

            pad[1, 0] = '0';
            pad[1, 1] = '2';
            pad[1, 2] = '3';
            pad[1, 3] = '4';
            pad[1, 4] = '0';

            pad[2, 0] = '5';
            pad[2, 1] = '6';
            pad[2, 2] = '7';
            pad[2, 3] = '8';
            pad[2, 4] = '9';

            pad[3, 0] = '0';
            pad[3, 1] = 'A';
            pad[3, 2] = 'B';
            pad[3, 3] = 'C';
            pad[3, 4] = '0';

            pad[4, 0] = '0';
            pad[4, 1] = '0';
            pad[4, 2] = 'D';
            pad[4, 3] = '0';
            pad[4, 4] = '0';
        }

        public string Resolve()
        {
            var lines = input.Split('\n');

            var code= new List<char>();

            foreach (var lineStr in lines)
            {
                foreach (var caracter in lineStr.ToCharArray())
                {
                    switch (caracter)
                    {
                        case 'U':
                            DecreaseLineIndex();
                            break;
                        case 'R':
                            IncreaseColumnIndex();
                            break;
                        case 'D':
                            IncreaseLineIndex();
                            break;
                        case 'L':
                            DecreaseColumnIndex();
                            break;
                    }
                }

                code.Add(pad[m_lineIndex, m_columnIndex]);
            }

            return $"Code: {code.Aggregate("", (current, number) => current + number)}";
        }

        private void IncreaseColumnIndex()
        {
            var newIndex = m_columnIndex + 1;

            if (newIndex < 4 && pad[m_lineIndex, newIndex] != '0')
                m_columnIndex++;
        }

        private void DecreaseColumnIndex()
        {
            var newIndex = m_columnIndex - 1;

            if (newIndex > 0 && pad[m_lineIndex, newIndex] != '0')
                m_columnIndex--;
        }

        private void IncreaseLineIndex()
        {
            var newIndex = m_lineIndex + 1;

            if (newIndex < 4 && pad[newIndex, m_columnIndex] != '0')
                m_lineIndex++;
        }

        private void DecreaseLineIndex()
        {
            var newIndex = m_lineIndex - 1;

            if (newIndex > 0 && pad[newIndex, m_columnIndex] != '0')
                m_lineIndex--;
        }

    }
}
