$(() => {
    $('.cart').on('click', (e) => {
        let curentItem = e.currentTarget;
        $.ajax({
            url: '/cart/add/' + $(curentItem).attr('data-id'),
            method: 'post',
            success: (data) => { console.log(data) },
            error: (err) => { console.log(err) }
        });
    });
    $('.basket').on('click', (e) => {
        $.ajax({
            url: '/cart/ShowSession',
            method: 'get',
            success: (data) => {
                console.log(data.length)
                console.log(data)
                var itemPrice = 0
                var basketItems;
                $('.basket-area').html("")
                for (var i = 0; i < data.length; i++) {
                     basketItems += `
                <li>
                    <div class="sc-productwrap">
                        <a href="~/product_details.html" class="sc-product-thumb">
                            <img src="${data[i].image}" alt="Product" class="img-fluid">
                        </a>
                        <div class="sc-product-details">
                            <a href="~/product_details.html" class="sc-product-ttl">${data[i].name}</a>
                            <p class="sc-product-sz">ivj</p>
                        </div>
                    </div> 
                    <div class="sc-quantity">
                        ${data[i].count}X <span class="sc-price"> ${data[i].total}</span>                                                                
                    </div>
                    <a href="javascript:void(0);" class="sc-produc-remove" data-id=${data[i].id}>
                        X
                    </a>
                </li>
                    `;
                    itemPrice += data[i].total;
                    
                    $('.basket-area').html(basketItems);
                    $('.hs-cart-circle').text(data.length);
                    $('.hs-cart-value').text(itemPrice);
                    $('.sb-cartbox-amount').text(itemPrice);
                    $('.basket-item-count1').text(data.length);








                    $('.sc-produc-remove').on('click', (e) => {
                        let curentItem = e.currentTarget;
                        $.ajax({
                            url: '/cart/Delete/' + $(curentItem).attr('data-id'),
                            method: 'get',
                            success: (data) => {
                                console.log(data.length)
                                console.log(data)
                                var itemPrice = 0
                                var basketItems;
                                $('.basket-area').html("")
                                for (var i = 0; i < data.length; i++) {
                                    basketItems += `
                <li>
                    <div class="sc-productwrap">
                        <a href="~/product_details.html" class="sc-product-thumb">
                            <img src="${data[i].image}" alt="Product" class="img-fluid">
                        </a>
                        <div class="sc-product-details">
                            <a href="~/product_details.html" class="sc-product-ttl">${data[i].name}</a>
                            <p class="sc-product-sz">ivj</p>
                        </div>
                    </div> 
                    <div class="sc-quantity">
                        ${data[i].count}X <span class="sc-price"> ${data[i].total}</span>                                                                
                    </div>
                    <a href="javascript:void(0);" class="sc-produc-remove">
                        X
                    </a>
                </li>
                    `;
                                    itemPrice += data[i].total;

                                    $('.basket-area').html(basketItems);
                                    $('.hs-cart-circle').text(data.length);
                                    $('.hs-cart-value').text(itemPrice);
                                    $('.sb-cartbox-amount').text(itemPrice);
                                    $('.basket-item-count1').text(data.length);
                                }
                                basketItems = " ";
                            },
                            error: (err) => { console.log(err) }
                        });
                    });

                }
                basketItems = " ";
            },
            error: (err) => { console.log(err) }
        });
    });






    



    //$('.increase').on('click', (e) => {
    //    let curentItem = e.currentTarget;
    //});

    //$('.decrease').on('click', (e) => {
    //    let curentItem = e.currentTarget;
    //});
})

function SetData(data) {
    document.querySelector(".basket-area").innerHTML = "";
    document.querySelector(".basket-area").innerHTML += "";
}