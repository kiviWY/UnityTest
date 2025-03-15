using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example_01
{
    public class Trie
    {
        private Trie[] children;
        private bool isEnd;

        public Trie()
        {
            children = new Trie[26];
            isEnd = false;
        }

        public void Insert(string word)
        {
            Trie node = this;
            char[] chars = word.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char ch = chars[i];
                // 字符的ASCLL编码， 'a’ 编码 97 ， ‘b’ 98   'z' 是122
                // ch小写字母  如 c ch-'a'=2 
                // index 的范围 0（对应 'a'）- 25(对应‘z’)
                int index = ch - 'a';

                if (node.children[index] == null)
                {
                    node.children[index] = new Trie();
                }

                node = node.children[index];
            }

            node.isEnd = true;
        }

        
        // 搜索是否已经存在某个单词（完整的，最后一定是end）
        public bool Search(string word)
        {
            Trie node = SearchPrefix(word);
            return node != null && node.isEnd;
        }

        // 是否已经存在
        public bool StartWith(string prefix)
        {
            Trie node = SearchPrefix(prefix);
            return node != null && node.isEnd;
        }

        Trie SearchPrefix(string prefix)
        {
           char[] chars = prefix.ToCharArray();
           Trie node = this;
           for (int i = 0; i < chars.Length; i++)
           {
               char ch = chars[i];
               int index = ch - 'a';
               if (node.children[index] == null)
               {
                   return null;
               }

               node = node.children[index];
           }

           return node;
        }
    }
}