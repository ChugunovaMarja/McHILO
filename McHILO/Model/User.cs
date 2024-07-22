using System;

namespace McHILO.Model
{
    public class User: IEquatable<User>
    {
        public string Name { get; }

        public User(string name)
        {
            Name = name;
        }
        public override bool Equals(Object obj)
        {
            return Equals(obj as User);
        }

        public bool Equals(User secondUser)
        {
            if (secondUser == null)
                return false;

            return this.Name.Equals(secondUser.Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
    }
