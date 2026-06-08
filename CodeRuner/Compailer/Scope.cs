using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeRuner.Compailer
{
    /// <summary>
    /// Improved Scope management for symbol tables with proper nested scope support
    /// </summary>
    public class Scope
    {
        public class Definition
        {
            public string SymbolName { get; set; }
            public string SymbolType { get; set; }
            public string Kind { get; set; } // "variable", "function", "scope"
            
            public override string ToString()
            {
                return $"{SymbolName}: {SymbolType} ({Kind})";
            }
        }

        // Stack of scopes - each scope is a dictionary
        private List<Dictionary<string, Definition>> _scopes;
        
        public Scope()
        {
            _scopes = new List<Dictionary<string, Definition>>();
            EnterScope(); // Global scope
        }

        /// <summary>
        /// Enter a new scope (e.g., for functions, blocks)
        /// </summary>
        public void EnterScope()
        {
            _scopes.Add(new Dictionary<string, Definition>(StringComparer.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Exit current scope and remove all symbols in it
        /// </summary>
        public void ExitScope()
        {
            if (_scopes.Count > 1) // Keep at least global scope
            {
                _scopes.RemoveAt(_scopes.Count - 1);
            }
        }

        /// <summary>
        /// Add a symbol to current scope
        /// </summary>
        public bool AddSymbol(string symbolName, string type, string kind = "variable")
        {
            symbolName = symbolName.ToLower();
            
            // Check if symbol exists in current scope
            if (_scopes.Count > 0)
            {
                var currentScope = _scopes[_scopes.Count - 1];
                if (currentScope.ContainsKey(symbolName))
                {
                    return false; // Symbol already exists in this scope
                }
                currentScope[symbolName] = new Definition
                {
                    SymbolName = symbolName,
                    SymbolType = type,
                    Kind = kind
                };
                return true;
            }
            return false;
        }

        /// <summary>
        /// Find a symbol starting from innermost scope outward
        /// </summary>
        public Definition FindSymbol(string symbolName)
        {
            symbolName = symbolName.ToLower();
            
            // Search from innermost to outermost scope
            for (int i = _scopes.Count - 1; i >= 0; i--)
            {
                if (_scopes[i].TryGetValue(symbolName, out var definition))
                {
                    return definition;
                }
            }
            return null;
        }

        /// <summary>
        /// Check if symbol exists in current scope only (not parent scopes)
        /// </summary>
        public bool FindInScope(string symbolName, string kind)
        {
            symbolName = symbolName.ToLower();
            
            if (_scopes.Count > 0)
            {
                var currentScope = _scopes[_scopes.Count - 1];
                if (currentScope.TryGetValue(symbolName, out var definition))
                {
                    // Check if it's a scope marker or same kind
                    if (definition.Kind == "scope" || definition.Kind == kind)
                    {
                        return false; // Already defined
                    }
                }
                return true; // Can add
            }
            return true;
        }

        /// <summary>
        /// Get all symbols in current scope
        /// </summary>
        public List<Definition> GetCurrentScopeSymbols()
        {
            if (_scopes.Count > 0)
            {
                return _scopes[_scopes.Count - 1].Values.ToList();
            }
            return new List<Definition>();
        }

        /// <summary>
        /// Clear all scopes and reset
        /// </summary>
        public void Clear()
        {
            _scopes.Clear();
            EnterScope();
        }

        /// <summary>
        /// Get scope depth (for debugging)
        /// </summary>
        public int ScopeDepth => _scopes.Count;
    }
}
