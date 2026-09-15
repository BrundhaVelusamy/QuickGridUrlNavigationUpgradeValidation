namespace QuickGridUrlNavigationSampleNET10To11.Components;

public static class QuickGridSampleData
{
    public static IQueryable<SampleRecord> Records { get; } =
    new SampleRecord[]
    {
        new(1, "Ada", "London", new DateOnly(2024, 1, 15)),
        new(2, "Ben", "Seattle", new DateOnly(2024, 2, 20)),
        new(3, "Cora", "Berlin", new DateOnly(2024, 3, 5)),
        new(4, "Diego", "Madrid", new DateOnly(2024, 4, 18)),
        new(5, "Elena", "Rome", new DateOnly(2024, 5, 9)),
        new(6, "Farah", "Cairo", new DateOnly(2024, 6, 27)),
        new(7, "Gus", "Oslo", new DateOnly(2024, 7, 11)),
        new(8, "Hana", "Tokyo", new DateOnly(2024, 8, 23)),
        new(9, "Ivan", "Prague", new DateOnly(2024, 9, 14)),
        new(10, "Jules", "Paris", new DateOnly(2024, 10, 30)),
        new(11, "Kai", "Dublin", new DateOnly(2024, 11, 6)),
        new(12, "Lina", "Lisbon", new DateOnly(2024, 12, 19)),
        new(13, "Mina", "Seoul", new DateOnly(2025, 1, 8)),
        new(14, "Noah", "Toronto", new DateOnly(2025, 2, 16)),
        new(15, "Omar", "Dubai", new DateOnly(2025, 3, 25)),
        new(16, "Priya", "Delhi", new DateOnly(2025, 4, 12)),
        new(17, "Quinn", "Boston", new DateOnly(2025, 5, 21)),
        new(18, "Rose", "Dubai", new DateOnly(2025, 3, 25)),
        new(19, "Anna", "Delhi", new DateOnly(2025, 4, 12)),
        new(20, "Bella", "Boston", new DateOnly(2025, 5, 21))
    }.AsQueryable();
}

public sealed record SampleRecord(int Id, string Name, string City, DateOnly Joined);
