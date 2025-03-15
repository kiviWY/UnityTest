using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RedNode
{
    private int redNum;
    private string key;
    private Dictionary<string, RedNode> children;
    private Action<int> redNumChangeCall;

    public int RedNum => redNum;
    public RedNode(string key)
    {
        this.key = key;
        children = new Dictionary<string, RedNode>();
    }

    public void SetChangeCall(Action<int> redNumChangeCall)
    {
        this.redNumChangeCall = redNumChangeCall;
    }

    public void AddRedNum(int changeNum)
    {
        this.redNum += changeNum;  // todo 夹逼方法
        if (redNum < 0)
        {
            redNum = 0;
        }
        
        
        redNumChangeCall?.Invoke(this.redNum);
    }




    /// <summary>
    /// 增加节点
    /// </summary>
    /// <param name="path">节点路径</param>
    /// <param name="isAddRedNum">默认为true，如果是ui创建的，则为false，因为ui只是创建节点，不增加节点上红点数量</param>
    /// <returns></returns>
    public RedNode AddNode(string path ,bool isAddRedNum = true)
    {
        var nodekeys = path.Split('|');
        if (nodekeys.Length <= 0) return null;
        var indexNode = this;
        if (isAddRedNum)
        {
            indexNode.AddRedNum(1);
        }

        for (int i = 0; i < nodekeys.Length ; i++)
        {
            var nodekey = nodekeys[i];
            var containsKey = indexNode.children.ContainsKey(nodekey);
            if (i == nodekeys.Length - 1&&containsKey)
            {
                var finalNode = indexNode.children[nodekey];
                if (isAddRedNum)
                {
                    if (finalNode.redNum <= 0)
                    {
                        finalNode.AddRedNum(1);
                    }
                }
                return  indexNode.children[nodekey];
            }
            
            if (containsKey)
            {
                indexNode = indexNode.children[nodekey];
                if (isAddRedNum)
                {
                    indexNode.AddRedNum(1);
                }
            }
            else
            {
                indexNode.children[nodekey] = new RedNode(nodekey);
                indexNode.children[nodekey].AddRedNum(1);
            }
        }

        return indexNode.children[nodekeys[nodekeys.Length - 1]];
    }


    public void DeleteRedNum(string path)
    {
        var nodekeys = path.Split('|');
        if (nodekeys.Length <= 0) return;
        var indexNode = this;
        for (int i = 0; i < nodekeys.Length; i++)
        {
            var nodekey = nodekeys[i];
            var containsKey = indexNode.children.ContainsKey(nodekey);
            if (containsKey)
            {
                indexNode = indexNode.children[nodekey];
                indexNode.AddRedNum(-1);
              
            }
        }
    }


    public RedNode GetNode(string key)
    {
        var nodekeys = key.Split('|');
        if (nodekeys.Length <= 0) return null;
        var indexNode = this;
        for (int i = 0; i < nodekeys.Length ; i++)
        {
            var nodekey = nodekeys[i];
            var containsKey = indexNode.children.ContainsKey(nodekey);
            if (containsKey)
            {
                indexNode = indexNode.children[nodekey];
                if (i == nodekeys.Length - 1)
                {
                    return indexNode;
                }
            }
            else
            {
                return null;
            }
        }

        return null;
    }
}



/// <summary>
///  红点管理类， 采用前缀树的形式，持有根节点 root
/// </summary>
public class RedPointSystem 
{
   private  RedNode root;
   
   private RedPointSystem()
   {
       root = new RedNode("root");
   }
   
   private static RedPointSystem instance;

   public static RedPointSystem Instance()
   {
       if (instance == null)
       {
           instance = new RedPointSystem();
       }
       return instance;
   }

   
   private RedNode searchNode(string path)
   {
       return this.root.GetNode(path);
   }
   
   # region 数据层操作
   
   /// 增加节点的操作，
   public void AddRedNode(string path)
   {
       this.root.AddNode(path,true);
   }
   
   # endregion 

   # region UI层操作

   public void AddUINode(string path, Action<int> changeRedNum)
   {
       var node = this.root.AddNode(path,false);
       if (node != null)
       {
           node.SetChangeCall(changeRedNum);
       }
   }

   public int GetUINodeRedNum(string path)
   {
       var node = this.searchNode(path);
       if (node == null)
       {
           return 0;
       }

       return node.RedNum;
   }


   /// <summary>
   ///  将对应节点的事件删除
   /// </summary>
   /// <param name="path"></param>
   public void DeleteUINode(string path)
   {
       // todo
   }

   public void DeleteUIRedNoteRedNum(string path)
   {
       this.root.DeleteRedNum(path);
   }

   # endregion 

}
