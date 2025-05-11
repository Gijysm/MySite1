import React from 'react';
import ReactDOM from 'react-dom';
import './lib/bootstrap/dist/css/site.css';

function Anim() {
    return (
        <div style={{ position: 'relative', overflow: 'hidden', height: '300px' }}>
            <div className="anim_back"></div>
            <h1 className="animated-gradient-header" style={{ position: 'relative', zIndex: 1 }}>
                My Repos
            </h1>
        </div>
    );
}

ReactDOM.render(<Anim />, document.getElementById('anim-root'));