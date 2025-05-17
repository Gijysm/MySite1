const AnimProgressbar = document.querySelectorAll('.progress-bar');

AnimProgressbar.forEach(el=>{
    const value = el.dataset.value;
    let current = 0;
    
    const animate = ()=>{
        if(current <= value){
            el.style.setProperty('--progress', `${current}%`);
            el.setAttribute('data-value', current);
            current++;
            requestAnimationFrame(animate);
        }
    }
    
    setTimeout(()=>{
        requestAnimationFrame(animate);
    }, 1);
});