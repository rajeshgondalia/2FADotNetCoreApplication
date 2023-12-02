# 2FADotNetCoreApplication


Dot Net Core Project Name : Test2FAApplication
1. First Run above project for generating and checking 2FA Google Authenticator

Controller Name : TwoFactorAuthenticationController

A. I created Index method you need to pass emailid and mobileno then submit so, It will generated the barcode 2FA based on passed emailId.
   FYI, here i inserted whatever you passed emailid and mobileno on my db
B. You need to scan the barcode on authenticator application then you get the code on your mobile after you need to pass this code on textbox 
   here, I created one "EnableAuth" action those method is checking code is valid or not 
   
----------------------------------------------------------------

2. Dot Net Core Web API Project : Test2FAApplicationWebaPI

Controller Name : EmployeeController

A. I created below two api endpoint

A.A APIName : GetCodeByMobileNo
- FYI, We need to pass the mobileno based on we getting the code 

A.B APINAme : VerifiedPhonenobyCode
- FYI, we have code so, we need to pass the code then api is verify the code is valid or not 