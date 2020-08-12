# Narin-Analytics-Unity-SDK
When using different Analytics services, it happens that to validate the data of one analytics service, you implement another service next to it to compare the data to make sure the data is correct.

It also happens that from a service that gives you special features such as Mobile Attribution along with another service that gives you special features for checking certain metrics in F2P games.

Or when one of the data analysis services has a problem, you replace it with another service.

All of the above will involve changes to your code because the integration of each of these data analysis services is different, and ultimately causes the Open/Close principle to be disregarded in your codes.

This SDK by designing a general interface for all data analysis services in an attempt to solve these problems in using different data analysis services.

The advantages of this service for you include the following:

1) Designing an interface for the entire data analysis service so that the maximum possibilities of these services are covered and at the same time everyone follows a single interface
2) Minimize code changes when replacing or using multiple services at the same time
3) Integrate multiple data analysis services with just one implementation
4) Can be used in Distributed Build System to use different data analysis services for different releases

