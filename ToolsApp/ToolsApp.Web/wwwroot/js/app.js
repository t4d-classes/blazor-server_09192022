'use strict';

window.app = {
    setFocus(selector) {
        console.log("called setFocus with selector ", selector);
        const element = document.querySelector(selector);
        if (element) {
            element.focus();
        }
    },
    setupColorsRefresh(dotNetHelper) {
        
        console.log("setup colors refresh")
        
        document.querySelector("#refreshColors").addEventListener('click', async() => {
           
            console.log("called colors refresh")
            
            const colors = await dotNetHelper.invokeMethodAsync("All");
            console.log(colors);
        });
        
    }
};
