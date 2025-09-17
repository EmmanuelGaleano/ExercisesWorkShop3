using System;

namespace BridgesMadison.Core
{
    public class BridgeValidator
    {
        public bool Validate(string bridge)
        {
            // If null or too short, it's invalid
            if (string.IsNullOrEmpty(bridge)) return false;
            if (bridge.Length < 2) return false;

            // 1) Must start and end with '*'
            if (bridge[0] != '*' || bridge[^1] != '*') return false;

            // 2) Inner part (without the bases '*')
            string inner = bridge.Substring(1, bridge.Length - 2);

            // Inner part cannot contain '*'
            if (inner.Contains('*')) return false;

            // 3) Check symmetry: inner part must be a palindrome
            char[] arr = inner.ToCharArray();
            Array.Reverse(arr);
            string reversed = new string(arr);
            if (inner != reversed) return false;

            // 4) No 4 or more consecutive '='
            if (inner.Contains("====")) return false;

            // 5) If there is "===" it must be exactly in the center
            int tripleIndex = inner.IndexOf("===");
            if (tripleIndex != -1)
            {
                int centerStart = (inner.Length - 3) / 2;
                if (tripleIndex != centerStart) return false;
            }

            // 6) Each pair "==" must have a '+' to its left or right,
            //    except when that pair is part of the central "===" allowed.
            for (int i = 0; i < inner.Length - 1; i++)
            {
                if (inner[i] == '=' && inner[i + 1] == '=')
                {
                    // Skip pairs inside the central "==="
                    if (tripleIndex != -1 && (i == tripleIndex || i == tripleIndex + 1))
                        continue;

                    bool leftPlus = (i - 1 >= 0 && inner[i - 1] == '+');
                    bool rightPlus = (i + 2 < inner.Length && inner[i + 2] == '+');

                    if (!leftPlus && !rightPlus)
                        return false;
                }
            }

            // Passed all checks
            return true;
        }
    }
}
