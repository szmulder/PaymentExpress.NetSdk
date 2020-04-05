# PaymentExpress

Support the pxpay2.0 solution
https://www.windcave.com/Document/PXECOM_PXPay_2_0_IntegrationGuide.pdf

Test card numbers
https://www.windcave.com/support-merchant-frequently-asked-questions-testing-details


## Instructions

### How to use it
See the TestMvcCore Project

You need edit the appsettings.json
```c
{
  "PaymentExpressSettings": {
    "PxPayUserId": "your PxPayUserId",
    "PxPayKey": "your PxPayKey",
    "RequestUrl": "https://sec.windcave.com/pxaccess/pxpay.aspx."
  }...
```

You need modief the PxPayUserId and PxPayKey to your key