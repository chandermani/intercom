# Prerequisite
- .Net Core 3.1 SDK

# Running the code
- Clone the repo
- Open your command console
- Navigate to `Intercom` folder and run
	`dotnet restore`
	`dotnet build`
- To run tests from `Intercom` folder run
	`dotnet test`
- Then Navigate to folder `Intercom.Invite` and run
	`dotnet run ./customer.txt <outputfilePath>`
	This should generate the filter list of customers who are invited.


# Design and Implementation notes
- Project Intercom.Invite.Core contains the core implementation for invite
- The entry point into the system is the `CustomerInviteFilter`, that does the core customer filtering based filter criteria (distance)
- CustomerInviteFilter is supported by `CustomerListReader` that reads the input file in a line at a time fashion, and Func `DistanceCalculator.GreatCircleDistance` to calculate distances.
- Function `CustomerModelMapper.Default` is used to convert the customer json into Customer domain model

# Areas of Improvements
While this solution showcases my thought process and my ability to structure/organize code, it is in no way complete. 
Some areas that I believe still need to be addressed here are
1. Negative flows. 
	a. What happens if line items in json file are not well formed? 
	b. What happens if long/lat coordinates are invalid? Do we reject such erroneous records or should the program halt?
	c. What happens if the file does not exist?
	d. Other I/O errors.
2. With negative flows there will also be a need to add more tests to verify negative flows.
3. Code in `Program.cs` that parses command line data and instantiates `CustomerInviteFilter` has very little validation in place.
4. What happens when the input list is too big? I believe i handle this by not reading the complete file. 
5. What happens if the output bigger is than what can fit in the memory. In such case we will require some external sorting techinques.

With such an exercise it is difficult to determine how far should one go and whether the time investment adds any significant value. 
My humble request here will be to not reject the solution if scenario mentioned above are not addressed, instead if these are an important part of the overall evaluation let me update my solution and make a new submission.
