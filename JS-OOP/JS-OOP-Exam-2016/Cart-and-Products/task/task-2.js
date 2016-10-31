/* globals module */

"use strict";

function solve(){
    let validator = {
        validateUndefinedParameter: function(value, name){
            name = name || "Value";
            if(typeof value === "undefined"){
                throw new Error(name + " must not be undefined");
            }
        },
        validateEmptyStringParameter: function(value, name){
            name = name || "Value";
            if(value === ""){
                throw new Error(name + " must not be an empty string");
            }
        },
        validateNumberParameter: function(value, name){
            name = name || "Value";
            if(typeof value !== "number"){
                throw new Error(name + " must be a number");
            }
        },
        validateAProductOrProductLikeObject: function(value,name){
            let isProduct = (typeof value === Product) ||
                (typeof value.productType === "string" &&
                 typeof value.name === "string" &&
                 typeof value.price === "number");

            if(!isProduct){
                throw new Error(name + " must be a valid product/product-like object");
            }
        }
    };

    class Product{
        constructor(productType, name, price){
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }

        set productType(value){
            validator.validateUndefinedParameter(value, "Product type");
            validator.validateEmptyStringParameter(value, "Product type");
            this._productType = value;
        }

        get name() {
            return this._name;
        }

        set name(value){
            validator.validateUndefinedParameter(value, "Product name");
            validator.validateEmptyStringParameter(value, "Product name");
            this._name = value;
        }

        get price() {
            return this._price;
        }

        set price(value){
            let convertIfPriceIsString = parseFloat(value);
            validator.validateUndefinedParameter(convertIfPriceIsString, "Product price");
            validator.validateNumberParameter(convertIfPriceIsString, "Product price");
            this._price = convertIfPriceIsString;
        }
    }

    class ShoppingCart {
        constructor(){
            this.products = [];
        }

        add(product){
            validator.validateUndefinedParameter(product, "Product to add");
            validator.validateAProductOrProductLikeObject(product, "Product to add");
            this.products.push(product);

            return this;
        }

        remove(product){
            if(this.products.length === 0){
                throw new Error("There are no products in the shopping cart to remove");
            }

            validator.validateUndefinedParameter(product, "Product to remove");
            validator.validateAProductOrProductLikeObject(product, "Product to remove");

            let canFindTheProduct = false;
            for(let i = 0, len = this.products.length; i < len; i += 1){
                if((product.productType === this.products[i].productType) &&
                    (product.name === this.products[i].name) &&
                    (product.price === this.products[i].price)){
                    this.products.splice(i, 1);
                    canFindTheProduct = true;
                    break;
                }
            }

            if(!canFindTheProduct){
                throw new Error("There is no such product in the cart");
            }
        }

        showCost(){
            let sum = 0;
            if(this.products.length === 0){
                return sum;
            }

            this.products.forEach(function(product){
                sum += product.price;
            });

            return sum;
        }

        showProductTypes(){
            let productTypes = {};
            this.products.forEach(product => {
                productTypes[product.productType] = true;
            });

            let sortedProductTypes =  Object.keys(productTypes).sort();

            return sortedProductTypes;
        }

        getInfo(){
            let returnedObject = {
                totalPrice: 0,
                products: []
            },
                names = "";

            if(this.products.length === 0){
                return returnedObject;
            }

            this.products.forEach(function(product){
                returnedObject.totalPrice += product.price;
            });

            this.products.forEach(function(p){
                if(!names.includes(p.name)){
                    let product = {
                        name: p.name,
                        totalPrice: p.price,
                        quantity: 1
                    };

                    returnedObject.products.push(product);

                    names += p.name;
                } else {
                    for(let i = 0, len = returnedObject.products.length; i < len; i += 1){
                        if(p.name === returnedObject.products[i].name){
                            returnedObject.products[i].price += p.price;
                            returnedObject.products[i].quantity += 1;
                            break;
                        }
                    }
                }
            });

            return returnedObject;
        }
    }

    return {
        Product, ShoppingCart
    };
}

module.exports = solve;
