namespace _3.StringDisperser
{
    using System;
    using System.Collections;

    public class StringDisperser : IComparable<StringDisperser>, IEnumerable
    {
        private string[] text;

        public StringDisperser(params string[] text)
        {
            this.Text = text;
        }

        public string[] Text
        {
            get { return this.text; }

            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentNullException("Text array can't be empty");
                }

                this.text = value;
            }
        }

        public override bool Equals(object obj)
        {
            StringDisperser stringDisperser = obj as StringDisperser;
            if (stringDisperser == null)
            {
                return false;
            }

            if (!(this.Text.Equals(stringDisperser.Text)))
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(StringDisperser a, StringDisperser b)
        {
            if (Object.ReferenceEquals(a, b))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(StringDisperser string1, StringDisperser string2)
        {
            return !Equals(string1, string2);
        }

        public override int GetHashCode()
        {
             return this.Text.GetHashCode();
        }

        public override string ToString()
        {
            return string.Join(", ", this.Text);
        }

        public object Clone()
        {
            string[] newTextArray = new string[this.Text.Length];
            for (int i = 0; i < newTextArray.Length; i++)
            {
                newTextArray[i] = this.Text[i];
            }

            return new StringDisperser(newTextArray);
        }

        public int CompareTo(StringDisperser other)
        {
            return this.ConcatenateText().CompareTo(other.ConcatenateText());
        }

        private string ConcatenateText()
        {
            string wholeString = String.Join("", this.Text);
            return wholeString;
        }

        public IEnumerator GetEnumerator()
        {
            string totalString = this.ConcatenateText();
            for (int i = 0; i < totalString.Length; i++)
            {
                yield return totalString[i];
            }
        }
    }
}
