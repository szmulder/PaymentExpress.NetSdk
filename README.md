# PaymentExpress

Support the pxpay2.0 solution
http://www.paymentexpress.com/document/pxecom_pxpay_2_0_integrationguide.pdf


## Instructions

### How to use it
See the TestMvcCore Project

You need edit the appsettings.json
```c
{
  "PaymentExpressSettings": {
    "PxPayUserId": "your PxPayUserId",
    "PxPayKey": "your PxPayKey",
    "RequestUrl": "https://sec.paymentexpress.com/pxaccess/pxpay.aspx"
  }...
```

You need modief the PxPayUserId and PxPayKey to your key