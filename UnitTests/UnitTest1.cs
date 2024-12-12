using NUnit.Framework;

namespace OldPhonePadProject.Tests
{
    [TestFixture]
    public class OldPhonePadTests
    {
        [Test]
        public void TestSingleKeyPress()
        {
            // Test for single key press for different digits
            Assert.AreEqual("A", Program.OldPhonePad("2#"));
            Assert.AreEqual("D", Program.OldPhonePad("3#"));
            Assert.AreEqual("G", Program.OldPhonePad("4#"));
        }

        [Test]
        public void TestMultipleKeyPresses()
        {
            // Test for multiple key presses for the same digit
            Assert.AreEqual("B", Program.OldPhonePad("22#"));
            Assert.AreEqual("C", Program.OldPhonePad("222#"));
            Assert.AreEqual("A", Program.OldPhonePad("2222#"));
        }

        [Test]
        public void TestLongerKeyPresses()
        {
            // Test for digits with 4 possible letters (7 and 9)
            Assert.AreEqual("P", Program.OldPhonePad("7#"));
            Assert.AreEqual("Q", Program.OldPhonePad("77#"));
            Assert.AreEqual("R", Program.OldPhonePad("777#"));
            Assert.AreEqual("S", Program.OldPhonePad("7777#"));
            Assert.AreEqual("W", Program.OldPhonePad("9#"));
        }

        [Test]
        public void TestSpaceAndZero()
        {
            // Test for space and zero for word separation
            Assert.AreEqual("HELLO", Program.OldPhonePad("4433555 555666#"));
            Assert.AreEqual("HELLO WORLD", Program.OldPhonePad("4433555 555666096667775553#"));
        }

        [Test]
        public void TestDeleteKey()
        {
            // Test for delete key (*)
            Assert.AreEqual("HEL", Program.OldPhonePad("4433555 555*#"));
            Assert.AreEqual("H", Program.OldPhonePad("4455555666**#"));
        }

        [Test]
        public void TestComplexInput()
        {
            // Test for more complex input with multiple operations
            Assert.AreEqual("ABC", Program.OldPhonePad("2222 22222 222222#"));
            Assert.AreEqual("GOOD", Program.OldPhonePad("4666 6663#"));
        }

        [Test]
        public void TestSpecialCharacters()
        {
            // Test for inputs with special characters
            Assert.AreEqual("&", Program.OldPhonePad("1#"));
            Assert.AreEqual("'", Program.OldPhonePad("11#"));
            Assert.AreEqual("(", Program.OldPhonePad("111#"));
        }

        [Test]
        public void TestEdgeCases()
        {
            // Test for edge cases and boundary conditions
            Assert.AreEqual("", Program.OldPhonePad("#"));
            Assert.AreEqual("", Program.OldPhonePad("*#"));
            Assert.AreEqual("", Program.OldPhonePad("**#"));
        }
    }
}