using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode._2016.Day4
{
    public class Room
    {
        private string m_input;

        private string m_encryptedName;
        public int SectorID;
        private string m_checksum;

        public Room(string line)
        {
            m_input = line;
            SetEncryptedName();
            SetSectorID();
            SetChecksum();
        }

        public bool IsReal()
        {
            var repeatedCharsGrouped = m_encryptedName.Replace("-","").ToCharArray().GroupBy(x => x);
            var repeatedCharsOrdered = repeatedCharsGrouped.OrderByDescending(y => y.Count()).ThenBy(y => y.Key).Distinct().ToArray();

            var checksumArray= m_checksum.ToCharArray();
            
            for (int i = 0; i < checksumArray.Length; i++)
            {
                if (checksumArray[i] != repeatedCharsOrdered[i].Key)
                {
                    return false;
                }
            }

            return true;
        }

        private void SetChecksum()
        {
            int startIndex = m_input.IndexOf('[') + 1;

            m_checksum = m_input.Substring(startIndex).TrimEnd(']');
        }

        private void SetSectorID()
        {
            int startIndex = m_input.LastIndexOf('-') + 1;

            int length = m_input.IndexOf('[') - startIndex;

            SectorID = int.Parse(m_input.Substring(startIndex, length));
        }

        private void SetEncryptedName()
        {
            m_encryptedName= m_input.Substring(0, m_input.LastIndexOf('-'));
        }

        public string Decypher()
        {
            StringBuilder sb= new StringBuilder();

            foreach (var encryptedChar in m_encryptedName.ToCharArray())
            {
                sb.Append(DecypherChar(encryptedChar));
            }

            return sb.ToString();
        }

        private char DecypherChar(char encryptedChar)
        {
            if (encryptedChar == '-')
                return ' ';

            char decypheredChar= encryptedChar;

            for (int i = 0; i < SectorID; i++)
            {
                if (decypheredChar == 'z')
                    decypheredChar = 'a';
                else
                    decypheredChar++;
            }

            return decypheredChar;
        }
    }
}
