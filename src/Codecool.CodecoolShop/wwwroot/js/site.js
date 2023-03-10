// FILTER PRODUCTS

function orderProducts() {
    const suppliersButtons = document.querySelectorAll("[name=suppliers]");
    const categoriesButtons = document.querySelectorAll("[name=categories]");

    suppliersButtons.forEach((supplierBtn) => {
        supplierBtn.addEventListener('click',
            () => {
                let currentCategoryId;
                const supplierId = supplierBtn.value;
                for (let category of categoriesButtons) {
                    if (category.checked) {
                        currentCategoryId = category.value;
                        break;
                    }
                }
                getProducts(currentCategoryId, supplierId);

                console.log(currentCategoryId, supplierId);
            });
    });

    categoriesButtons.forEach((categorieBtn) => {
        categorieBtn.addEventListener('click',
            () => {
                let currentSupplierId;
                let categoryId = categorieBtn.value;
                for (let supplier of suppliersButtons) {
                    if (supplier.checked) {
                        currentSupplierId = supplier.value;
                        break;
                    }
                }
                getProducts(categoryId, currentSupplierId);

                console.log(categoryId, currentSupplierId);
            });
    });
}

async function getProducts(categoryId, supplierId) {

    const URL = `/Product/FilteredProducts?categoryId=${categoryId}&supplierId=${supplierId}`;

    $.ajax({
        type: "POST",
        url: URL,
        cache: false,
        dataType: 'html',
        success: function (data) {
            $("#productContainer").html(data);
            displayCards();
        },
        error: function(response) {
            console.log("Failed to reload data");
        }
    });
}

// DISPLAY CARDS
function displayCards() {

    const seeMoreBtns = document.querySelectorAll(".see-more-btn");

    seeMoreBtns.forEach((button) => {
        button.addEventListener('click', (event) => {
            const card = event.target.previousElementSibling;
            const gradientBackground = event.target.previousElementSibling.querySelector(".card-bg-gradient");
            const cardBody = card.querySelector(".card-body")

            if (event.target.innerText === "See More...") {
                card.style.overflow = "visible";

                sectionHeight = cardBody.scrollHeight + 129 + 50;

                card.style.height = sectionHeight + "px";
                gradientBackground.style.display = "none";

                event.target.innerText = "See Less...";
            } else if (event.target.innerText === "See Less...") {
                card.style.overflow = "hidden";
                card.style.height = "360px";
                gradientBackground.style.display = "block";
                event.target.innerText = "See More...";
            }

        })
    })
}

// DISPLAY CART

function handleCart() {
    const cart = document.querySelector("#cart");
    

    cart.addEventListener('click', () => {
        toggleCartModal();
        getCart();
    }, { once: true })
}

async function getCart() {
    const URL = `/cart/cartpreview`;

    $.ajax({
        type: "POST",
        url: URL,
        cache: false,
        dataType: 'json',
        success: function (data) {
            const tableContainer = document.querySelector("#cartContainer table tbody")
            tableContainer.innerHTML = renderTableBody(data);
        },
        error: function (response) {
            console.log("Failed to reload data");
        }
    });
}

function toggleCartModal() {
    const cartTable = document.querySelector(".cart-container table");
    const cartBackground = document.querySelector("#modalBackground");
    const cart = document.querySelector("#cart");
    const icon = cart.querySelector("i")

    // icon
    icon.style.color = "#0366D6";
    icon.style.fontSize = "150px";
    icon.style.opacity = "0.5";

    // cart table
    setTimeout(() => {
        cartTable.style.opacity = "1";
    }, 400);

    // modal background
    cartBackground.style.position = "absolute";
    cartBackground.style.width = "100vw";
    cartBackground.style.height = "100vh";
    cartBackground.style.opacity = "0.8";

    // modal cart
    cart.style.transition = "all 1s ease";
    cart.style.transform = "rotate(-360deg) scale(1)";
    cart.style.height = "400px";
    cart.style.width = "40%"
    cart.style.right = "50px";
    cart.style.top = "100px";
    cart.style.background = "white";
    cart.style.borderRadius = "10%";

    //add event listener for closing modal
    cartBackground.addEventListener('click', () => {
        // cart table
        cartTable.style.opacity = "0";

        setTimeout(() => {
            // modal cart
            cart.style.transform = "rotate(0deg) scale(1)";
            cart.style.height = "35px";
            cart.style.width = "35.25px"
            cart.style.right = "0px";
            cart.style.top = "10px";
            cart.style.background = "#0366d6";
            cart.style.borderRadius = "25%";

            // icon
            icon.style.color = "white";
            icon.style.fontSize = "18px";
            icon.style.opacity = "1";

            // modal background
            cartBackground.style.opacity = "0";

            setTimeout(() => {
                cart.style.transition = "all 0.2s ease";
                cart.style.transform = "";

                cartBackground.style.position = "relative";
                cartBackground.style.width = "";
                cartBackground.style.height = "";

            }, 800)
        }, 275)

        

        cart.addEventListener('click', () => {
            toggleCartModal();
        }, { once: true })

    }, { once: true })
}

// ADD TO CART
function handleAddToCart() {
    const addToCartBtn = document.querySelectorAll(".add-to-cart-btn")
    
    addToCartBtn.forEach((button) => {
        button.addEventListener('click', () => {

            const productId = button.value;
            addToCartSession(productId);
        })
    })
}

function addToCartSession(id) {
    const URL = `/cart/buy/${id}`
    $.ajax({
        type: "POST",
        url: URL,
        cache: false,
        dataType: 'json',
        success: function (data) {
            const tableContainer = document.querySelector("#cartContainer table tbody")
            tableContainer.innerHTML = renderTableBody(data);
        },
        error: function (response) {
            console.log("Failed to reload data");
        }
    });
}

function renderTableBody(data) {
    let tableRows = "";
    for (product of data) {
        tableRows += `<tr>
                          <td>
                              <img src="/img/${product.product.name}.jpg" style="height: 100%; width: 50%; align-self: center; padding-top: 10px">
                          </td>
                          <td>${product.product.name}</td>
                          <td>${product.product.defaultPrice}</td>
                          <td>${product.product.defaultPrice * product.quantity}</td>
                      </tr>`;
    }

    return tableRows;
}

// EDIT CART
function handleEditCart() {
    const buy = "buy";
    const remove = "remove";
    const inputQuantity = document.querySelectorAll(".quantity-input")
    inputQuantity.forEach((input) => {
        let previousInputValue = parseInt(input.value);
        input.addEventListener('change', (event) => {
            const itemId = input.dataset.itemId;
            console.log(previousInputValue)
            parseInt(input.value) > parseInt(previousInputValue) ? updateCartContent(itemId, buy, event) : updateCartContent(itemId, remove, event)
            previousInputValue = input.value;
        })
    })
}

function updateCartContent(id, action, event) {
    const URL = `/cart/${action}/${id}`
    $.ajax({
        type: "POST",
        url: URL,
        cache: false,
        dataType: 'json',
        success: function (data) {
            const totalPrice = event.target.parentElement.parentElement.querySelector("#totalPrice h5");
            const productQuantity = event.target.value;
            let productPrice;
            
            data.forEach((product) => {
                if (product.product.id == id) {
                    productPrice = product.product.defaultPrice
                }
            })
            if (productQuantity == 0) {
                const productContainer = event.target.parentElement.parentElement.parentElement.parentElement;
                productContainer.remove();
                console.log(productContainer)
            } else {
                totalPrice.innerText = (productPrice * productQuantity).toFixed(2);
            }

            const totalProductsPriceDOM = document.querySelector("#totalProductsPrice");
            const totalProductsPrice = data.reduce((a, b) => {
                return a + (b.product.defaultPrice * b.quantity);
            }, 0)
            totalProductsPriceDOM.innerText = totalProductsPrice.toFixed(2);
        },
        error: function (response) {
            console.log("Failed to reload data");
        }
    });
}

// PAYMENT METHOD
/*(function () {
    'use strict'

    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation')

        // Loop over them and prevent submission
        Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault()
                    event.stopPropagation()
                }
                form.classList.add('was-validated')
            }, false)
        })
    }, false)
}())*/

handleEditCart();

handleAddToCart();

displayCards();

orderProducts();

handleCart();
