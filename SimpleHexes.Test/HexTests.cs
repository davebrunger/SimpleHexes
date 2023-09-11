namespace SimpleHexes.Test;

public class HexTests
{
    [Test]
    [TestCaseSource(nameof(TestSTestCases))]
    public void TestS(int q, int r, int expectedS)
    {
        Assert.Multiple(() =>
        {
            var hex = new Hex(q, r);
            Assert.That(hex.Q, Is.EqualTo(q));
            Assert.That(hex.R, Is.EqualTo(r));
            Assert.That(hex.S, Is.EqualTo(expectedS));
        });
    }

    public static IEnumerable<TestCaseData> TestSTestCases
    {
        get
        {
            var prefix = $"{nameof(Hex)}_{nameof(Hex.S)}";
            yield return new TestCaseData(0, 0, 0).SetName($"{prefix} Q=0, R=0");
            yield return new TestCaseData(0, 1, -1).SetName($"{prefix} Q=0, R=1");
            yield return new TestCaseData(1, 0, -1).SetName($"{prefix} Q=1, R=0");
            yield return new TestCaseData(1, 1, -2).SetName($"{prefix} Q=1, R=1");
            yield return new TestCaseData(-1, -1, 2).SetName($"{prefix} Q=-1, R=-1");
            yield return new TestCaseData(2, 3, -5).SetName($"{prefix} Q=2, R=3");
            yield return new TestCaseData(-4, 5, -1).SetName($"{prefix} Q=-4, R=5");
            yield return new TestCaseData(5, -6, 1).SetName($"{prefix} Q=5, R=-6");
            yield return new TestCaseData(-7, -8, 15).SetName($"{prefix} Q=-7, R=-8");
            yield return new TestCaseData(9, -9, 0).SetName($"{prefix} Q=9, R=-9");
        }
    }

    [Test]
    [TestCaseSource(nameof(TestDistanceToTestCases))]
    public void TestDistanceTo(int q1, int r1, int q2, int r2, int expectedDistance)
    {
        Assert.Multiple(() =>
        {
            var hex1 = new Hex(q1, r1);
            var hex2 = new Hex(q2, r2);
            Assert.That(hex1.GetDistanceTo(hex2), Is.EqualTo(expectedDistance));
            Assert.That(hex2.GetDistanceTo(hex1), Is.EqualTo(expectedDistance));
        });
    }

    public static IEnumerable<TestCaseData> TestDistanceToTestCases
    {
        get
        {
            var prefix = $"{nameof(Hex)}_{nameof(HexExtensions.GetDistanceTo)}";
            yield return new TestCaseData(0, 0, 0, 0, 0).SetName($"{prefix} (0, 0) => (0, 0)");
            yield return new TestCaseData(0, 0, 0, 1, 1).SetName($"{prefix} (0, 0) => (0, 1)");
            yield return new TestCaseData(0, 0, 1, 0, 1).SetName($"{prefix} (0, 0) => (1, 0)");
            yield return new TestCaseData(0, 0, 1, 1, 2).SetName($"{prefix} (0, 0) => (1, 1)");
            yield return new TestCaseData(0, 0, 1, -1, 1).SetName($"{prefix} (0, 0) => (1, -1)");
            yield return new TestCaseData(0, 0, -1, 1, 1).SetName($"{prefix} (0, 0) => (-1, 1)");
            yield return new TestCaseData(0, 0, 0, -1, 1).SetName($"{prefix} (0, 0) => (0, -1)");
            yield return new TestCaseData(0, 0, -1, 0, 1).SetName($"{prefix} (0, 0) => (-1, 1)");
            yield return new TestCaseData(0, 0, -1, -1, 2).SetName($"{prefix} (0, 0) => (-1, -1)");
            yield return new TestCaseData(2, 3, 4, 5, 4).SetName($"{prefix} (2, 3) => (4, 5)");
            yield return new TestCaseData(7, 3, 4, -5, 11).SetName($"{prefix} (2, 3) => (4, 5)");
        }
    }
}