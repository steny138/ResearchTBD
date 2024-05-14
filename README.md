# Research Truck-based-Development

Tunck Base Development (TBD) 廣為所知是由 Paul Hammant 於 2013-04-05 在 [What is Trunk-Based Development](https://paulhammant.com/2013/04/05/what-is-trunk-based-development/) 發表提出

深入了解此開發模式，越發覺得非常符合現代迭代的開發精神，與持續整合的精神高度吻合，很適合帶入工作團隊內的使用運作。

但要達成TBD工作流, 實作 branch by abstration 必不可少，透過BBA才能在不斷地將feature分支不斷合併到主幹分支之餘，
還能控管功能上線狀況，配合現實的業務模式。

因此分享目前使用中由.Net 8 WebAPI專案提供範例的開發方式，希望能得到他人建議進而讓這種開發方式能得到更好發展。

## 作法
1. HelloWorldController 直接回傳 "Hello World"
2. 實作 IHelloWorldBranch 
    - HelloWorldBranch，複製原始的開發程式碼 (顯示 "Hello World")
    - HelloNet8Branch，編輯新需求的開發程式碼 (顯示 "Hello .Net 8.")
3. 先重構 HelloWorldController 透過 IHelloWorldBranch.Show() 來顯示回傳值
4. appSetting.json FeatureManagement.HelloWorld 設定為false, 使用原本的開發程式碼
5. 此時已經重構完成，並且可以commit & push 且可合併到主幹分支，且不用擔心會影響production 運行程式碼
6. 待需求需上線時，將 appSetting.json FeatureManagement.HelloWorld 設定為true，即可置換新開發完成的需求程式碼

## TODO
現在的設定都是透過 appSetting.json FeatureManagement 來做開關設定，但若是運行於線上的程式碼，則需要改變 appSetting後重新部署才可運行新需求程式碼。

預期應可直接在線上運行中直接使用功能開關切換 BBA Branch，達到免停機的功能開關切換。
ex: 使用 Azure 的 AppConfiguration內的功能管理員來取代 appSetting.json FeatureManagement，即可達到線上切換的效果。