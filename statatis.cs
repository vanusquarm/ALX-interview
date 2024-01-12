using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class YourDbContext : DbContext
{
    // Your DbSet for the transactions
    public DbSet<Transaction> Transactions { get; set; }

    // ... other DbSet declarations and DbContext configuration

    public IQueryable<TransactionStatistic> GetDailyStatistics(DateTime startDate)
    {
        return Transactions
            .Where(t => t.TransactionDate >= startDate)
            .GroupBy(t => EF.Functions.DatePart("yyyy-mm-dd", t.TransactionDate))
            .Select(g => new TransactionStatistic
            {
                Date = g.Key,
                TransactionCount = g.Count(),
                TotalAmount = g.Sum(t => t.Amount)
            });
    }

    public IQueryable<TransactionStatistic> GetWeeklyStatistics(DateTime startDate)
    {
        return Transactions
            .Where(t => t.TransactionDate >= startDate)
            .GroupBy(t => EF.Functions.DatePart("ww", t.TransactionDate))
            .Select(g => new TransactionStatistic
            {
                Week = g.Key,
                TransactionCount = g.Count(),
                TotalAmount = g.Sum(t => t.Amount)
            });
    }

    public IQueryable<TransactionStatistic> GetMonthlyStatistics(DateTime startDate)
    {
        return Transactions
            .Where(t => t.TransactionDate >= startDate)
            .GroupBy(t => EF.Functions.DatePart("yyyy-mm", t.TransactionDate))
            .Select(g => new TransactionStatistic
            {
                Month = g.Key,
                TransactionCount = g.Count(),
                TotalAmount = g.Sum(t => t.Amount)
            });
    }

    public IQueryable<TransactionStatistic> GetQuarterlyStatistics(DateTime startDate)
    {
        return Transactions
            .Where(t => t.TransactionDate >= startDate)
            .GroupBy(t => EF.Functions.DatePart("yyyy-q", t.TransactionDate))
            .Select(g => new TransactionStatistic
            {
                Quarter = g.Key,
                TransactionCount = g.Count(),
                TotalAmount = g.Sum(t => t.Amount)
            });
    }

    public IQueryable<TransactionStatistic> GetYearlyStatistics(DateTime startDate)
    {
        return Transactions
            .Where(t => t.TransactionDate >= startDate)
            .GroupBy(t => EF.Functions.DatePart("yyyy", t.TransactionDate))
            .Select(g => new TransactionStatistic
            {
                Year = g.Key,
                TransactionCount = g.Count(),
                TotalAmount = g.Sum(t => t.Amount)
            });
    }
}

public class Transaction
{
    public int Id { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }

    // ... other properties
}

public class TransactionStatistic
{
    public DateTime? Date { get; set; }
    public int? Week { get; set; }
    public int? Month { get; set; }
    public int? Quarter { get; set; }
    public int? Year { get; set; }
    public int TransactionCount { get; set; }
    public decimal TotalAmount { get; set; }
}
