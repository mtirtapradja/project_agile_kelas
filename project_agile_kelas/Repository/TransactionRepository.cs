﻿using project_agile_kelas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project_agile_kelas.Repository
{
    public class TransactionRepository
    {
        private static DatabaseEntities db = new DatabaseEntities();

        public static int getAllSpending(int userId)
        {
            List<TransactionHeader> head = db.TransactionHeaders.Where(x => x.userId == userId && x.transactionTypeId == 2).ToList();
            return head.Sum(x => x.price);
        }

        public static int sumAllIncome(int userId)
        {
            List<TransactionHeader> head = db.TransactionHeaders.Where(x => x.userId == userId && x.transactionTypeId == 1).ToList();
            return head.Sum(x => x.price);
        }

        public static List<TransactionHeader> GetAllTrasactions()
        {
            return (from x in db.TransactionHeaders select x).ToList();
        }
        public static List<TransactionHeader> GetAllTrasactionByUser(int userId)
        {
            return (from x in db.TransactionHeaders where x.userId == userId select x).ToList();
        }

        

        public static TransactionHeader getTransactionById(int id)
        {
            return (from x in db.TransactionHeaders where x.transactionId == id select x).FirstOrDefault(); 
        }

        public static List<TransactionType> getAllTransactionType()
        {
            return db.TransactionTypes.ToList();
        }

        public static bool InsertTransaction(TransactionHeader newTransaction)
        {
            if (newTransaction != null)
            {
                db.TransactionHeaders.Add(newTransaction);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool UpdateTransaction(TransactionHeader currTransaction)
        {

            if (currTransaction != null)
            {
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteTransaction(TransactionHeader currTransaction)
        {
            if (currTransaction != null)
            {
                db.TransactionHeaders.Remove(currTransaction);
                db.SaveChanges();
                return true;
            }
            return false;
        }

    }
}