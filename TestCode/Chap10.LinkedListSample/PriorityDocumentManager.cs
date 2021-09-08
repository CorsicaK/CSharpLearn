using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.LinkedListSample
{
    public class PriorityDocumentManager
    {
        //包含所有文档
        private readonly LinkedList<Document> documentList;
        //包含最多10个元素的引用，是添加指定优先级新文档的入口
        private readonly List<LinkedListNode<Document>> priorityNodes;

        public PriorityDocumentManager()
        {
            documentList = new LinkedList<Document>();
            priorityNodes = new List<LinkedListNode<Document>>(10);
            for (int i = 0; i < 10; i++)
            {
                priorityNodes.Add(new LinkedListNode<Document>(null));
            }
        }

        public void AddDocument(Document d)
        {
            if (d == null)
                throw new ArgumentNullException("d");
            AddDocumentToPriorityNode(d, d.Priority);
        }

        private void AddDocumentToPriorityNode(Document doc, int priority)
        {
            //1.检查优先级是否在允许范围内
            if (priority > 9 || priority < 0)
                throw new ArgumentException("Priority must be between 0 and 9");
            //2.检查该优先级节点是否已有值
            if (priorityNodes[priority].Value == null)
            {
                //递减优先级值检查是否有低一级的优先级节点
                --priority;
                if (priority >= 0)
                {
                    //递归寻找
                    AddDocumentToPriorityNode(doc, priority);
                }
                else
                {
                    //如果不存在，添加到末尾，并且该链表节点由负责制定文档优先级的优先级节点引用
                    documentList.AddLast(doc);
                    priorityNodes[doc.Priority] = documentList.Last;
                }
                return;

            }
            else
            {
                //3.如果存在这样的节点
                LinkedListNode<Document> prioNode = priorityNodes[priority];
                //3.1存在指定优先级值的优先级节点
                if (priority == doc.Priority)
                {
                    //插入到优先级值的后面
                    documentList.AddAfter(prioNode,doc);
                    priorityNodes[doc.Priority] = prioNode.Next;
                }
                else //3.2引用文档的优先级节点有较低的优先级
                {
                    //通过while循环找到优先级值相同的第一个文档
                    LinkedListNode<Document> firstPrioNode = prioNode;
                    while(firstPrioNode .Previous!=null &&
                        firstPrioNode .Previous.Value .Priority ==prioNode .Value .Priority)
                    {
                        firstPrioNode = prioNode.Previous;
                        prioNode = firstPrioNode;
                    }
                    //新文档插入优先级值与优先级节点相同的所有文档的前面
                    documentList.AddBefore(firstPrioNode, doc);
                    priorityNodes[doc.Priority] = firstPrioNode.Previous;
                }
            }
        }

        /// <summary>
        /// 显示每个文档的优先级和标题
        /// </summary>
        public void DisplayAllNodes()
        {
            foreach(Document doc in documentList)
            {
                Console.WriteLine("PRIORITY:{0},TITLE:{1}", doc.Priority, doc.Title);
            }
        }

        /// <summary>
        /// 从链表中返回第一个文档（优先级最高的），并且删除它
        /// </summary>
        /// <returns></returns>
        public Document GetDocument()
        {
            Document doc = documentList.First.Value;
            documentList.RemoveFirst();
            return doc;
        }
    }
}
