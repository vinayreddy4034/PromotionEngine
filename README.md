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


