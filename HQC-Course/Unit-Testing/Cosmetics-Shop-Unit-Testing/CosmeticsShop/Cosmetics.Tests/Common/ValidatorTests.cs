using Cosmetics.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Common
{
    [TestFixture]
    public class ValidatorTests
    {
        [Test]
        public void CheckIfNull_WhenObjParamNullIsPassed_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(null));
        }

        [Test]
        public void CheckIfNull_WhenObjParamIsValidObject_ShouldNotThrowAnyException()
        {
            var obj = new object();

            Assert.DoesNotThrow(() => Validator.CheckIfNull(obj));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParamIsNull_ShouldThrowNullReferenceException()
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(null));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParamIsEmpty_ShouldThrowNullReferenceException()
        {

            string param = String.Empty;

            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(param));
        }

        [Test]
        public void CheckIfStringIsNullOrEmpty_WhenTextParamIsValidString_ShouldNotThrowAnyException()
        {
            string param = "valid string";

            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(param));
        }

        [TestCase("as")]
        [TestCase("too long case")]
        public void CheckIfStringLengthIsValid_WhenTextParamIsTooShortOrTooLong_ShouldThrowIndexOutOfRangeException(string text)
        {
            int max = 10;
            int min = 3;

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        public void CheckIfStringLengthIsValid_WhenTextParamIsInTheBoundaries_ShouldNotThrowAnyException()
        {
            int max = 10;
            int min = 3;
            string text = "valid";

            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
