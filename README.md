# PromotionEngine

Exposed Asp.net Core Web Api services. It take Product(SKU) and Quantity and Returns Result containing Total amount and order details


Input should be in JSON format
[
  {
    "productId": "A",
    "quantity": 5
  },
  {
    "productId": "B",
    "quantity": 2
  }
]

![Alt text](https://github.com/vinayreddy4034/PromotionEngine/blob/main/Snapshots/Input.jpg?raw=true "Input")

Output will come in following format

{
  "items": [
    {
      "productId": "A",
      "quantity": 5
    },
    {
      "productId": "B",
      "quantity": 2
    }
  ],
  "totalAmount": 290
}

![Alt text](https://github.com/vinayreddy4034/PromotionEngine/blob/main/Snapshots/Output.jpg?raw=true "Input")


