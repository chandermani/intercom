using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Intercom.Invite.Tests
{
    public class Invite
    {
        [Theory]
        [MemberData(nameof(AcceptanceTestInputs))]
        public void When_a_list_of_customers_are_provided_should_invite_customers_in_100_km_range(string inputFilePath, GPSCoordinate source, List<int> expectedInvitedCustomers)
        {
            
            // Arrange
            CustomerInviteFilter target = BuildTarget(inputFilePath);

            // Act
            var result = target.Filter(source, 100);

            // Assert
            result.OrderBy(c => c.Id)
                .Select(c => c.Id).ShouldBe(expectedInvitedCustomers);
        }

        [Theory]
        [MemberData(nameof(OtherRadiusInputs))]
        public void When_a_list_of_customers_are_provided_should_invite_customers_in_expected_km_range(string inputFilePath,double radius, GPSCoordinate source, List<int> expectedInvitedCustomers)
        {

            // Arrange
            CustomerInviteFilter target = BuildTarget(inputFilePath);

            // Act
            var result = target.Filter(source, radius);

            // Assert
            result.OrderBy(c => c.Id)
                .Select(c => c.Id).ShouldBe(expectedInvitedCustomers);
        }

        private CustomerInviteFilter BuildTarget(string customerListFilePath)
        {
            return new CustomerInviteFilter(new CustomerListReader(customerListFilePath, CustomerModelMapper.Default),
                                          DistanceCalculator.GreatCircleDistance);
        }

        public static IEnumerable<object[]> AcceptanceTestInputs =>
           new List<object[]>
           {
                new object[] { "./TestInputs/customers.txt",
                                new GPSCoordinate(53.339428d, -6.257664),
                                new List<int>() { 4, 5, 6, 8, 11, 12, 13, 15, 17, 23, 24, 26, 29, 30, 31, 39 } }
           };


        public static IEnumerable<object[]> OtherRadiusInputs =>
           new List<object[]>
           {
                new object[] { "./TestInputs/customers.txt",
                                20,
                                new GPSCoordinate(53.339428d, -6.257664),
                                new List<int>() { 4 } },

                 new object[] { "./TestInputs/customers.txt",
                                200,
                                new GPSCoordinate(52.339428d, -7.257664),
                                new List<int>() { 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 18, 21, 25, 26, 28, 29, 30, 31, 39 } }
           };
    }


}
