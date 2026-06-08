using System;
using System.Collections.Generic;

namespace CodeRuner
{
    /// <summary>
    /// Type conversion and compatibility checker for CodN language
    /// Improved with proper type hierarchy and conversion rules
    /// </summary>
    internal class tabdil_noe
    {
        // Type hierarchy (lower index = lower precedence)
        private static readonly Dictionary<string, int> TypeHierarchy = new Dictionary<string, int>
        {
            { "byte", 0 },
            { "int", 1 },
            { "double", 2 },
            { "bool", 3 },
            { "string", 4 },
            { "void", 5 },
            { "no_type", -1 }
        };

        /// <summary>
        /// Get type precedence level
        /// </summary>
        public int GetTypeLevel(string type)
        {
            if (string.IsNullOrEmpty(type)) return -1;
            type = type.ToLower();
            return TypeHierarchy.TryGetValue(type, out var level) ? level : -1;
        }

        /// <summary>
        /// Determine result type of binary operation (promote to higher type)
        /// </summary>
        public string karan_bala(string type1, string type2)
        {
            if (type1 == "no_type" || type2 == "no_type") 
                return "no_type";
            
            if (type1 == type2) 
                return type1;
            
            int level1 = GetTypeLevel(type1);
            int level2 = GetTypeLevel(type2);
            
            // For numeric types, promote to higher precision
            if (level1 >= 0 && level1 <= 2 && level2 >= 0 && level2 <= 2)
            {
                return Math.Max(level1, level2) switch
                {
                    0 => "byte",
                    1 => "int",
                    2 => "double",
                    _ => "double"
                };
            }
            
            // Default: return the higher level type
            return level1 > level2 ? type1 : type2;
        }

        /// <summary>
        /// Check if type conversion is allowed (type1 can be assigned to type2)
        /// </summary>
        public bool tabdil_pazir(string sourceType, string targetType)
        {
            if (sourceType == "no_type" || targetType == "no_type")
                return false;
            
            if (sourceType == targetType)
                return true;
            
            int sourceLevel = GetTypeLevel(sourceType);
            int targetLevel = GetTypeLevel(targetType);
            
            // Allow implicit numeric conversions (byte -> int -> double)
            if (sourceLevel >= 0 && sourceLevel <= 2 && targetLevel >= 0 && targetLevel <= 2)
            {
                return sourceLevel <= targetLevel;
            }
            
            return false;
        }

        /// <summary>
        /// Check if types are incompatible (for error reporting)
        /// Returns true if there's a type mismatch error
        /// </summary>
        public bool bareCnoe(string type1, string type2)
        {
            if (type1 == "no_type" || type2 == "no_type")
                return false; // Error already reported elsewhere
            
            // Same types are always compatible
            if (type1 == type2)
                return false;
            
            // Check if conversion is possible
            return !tabdil_pazir(type1, type2);
        }

        /// <summary>
        /// Check if type is numeric
        /// </summary>
        public bool IsNumeric(string type)
        {
            int level = GetTypeLevel(type);
            return level >= 0 && level <= 2;
        }

        /// <summary>
        /// Check if type is boolean
        /// </summary>
        public bool IsBoolean(string type)
        {
            return type?.ToLower() == "bool";
        }
    }
}
