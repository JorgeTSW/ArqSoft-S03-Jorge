// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.
// Write your JavaScript code.

(function () {
    const canvas = document.createElement('canvas');
    canvas.style.position = 'fixed';
    canvas.style.top = '0';
    canvas.style.left = '0';
    canvas.style.width = '100%';
    canvas.style.height = '100%';
    canvas.style.pointerEvents = 'none';
    canvas.style.zIndex = '0';
    document.body.appendChild(canvas);

    const ctx = canvas.getContext('2d');
    let width, height, pieces;

    const shapes = [
        [[0, 0], [1, 0], [2, 0], [3, 0]], // I
        [[0, 0], [0, 1], [1, 1], [2, 1]], // J
        [[0, 1], [1, 1], [2, 1], [2, 0]], // L
        [[0, 0], [1, 0], [0, 1], [1, 1]], // O
        [[1, 0], [2, 0], [0, 1], [1, 1]], // S
        [[0, 0], [1, 0], [2, 0], [1, 1]], // T
        [[0, 0], [1, 0], [1, 1], [2, 1]]  // Z
    ];

    // Paleta neon fucsia/morado — cámbiala aquí si cambias el tema
    const colors = [
        '255, 0, 255',    // magenta neon
        '204, 0, 255',    // fucsia
        '153, 0, 255',    // morado
        '255, 68, 255',   // magenta claro
    ];

    function init() {
        width = canvas.width = window.innerWidth;
        height = canvas.height = window.innerHeight;
        pieces = [];

        for (let i = 0; i < 40; i++) {
            pieces.push({
                x: Math.random() * width,
                y: Math.random() * height,
                speed: Math.random() * 0.8 + 0.3,
                rotation: Math.random() * Math.PI * 2,
                rotSpeed: (Math.random() - 0.5) * 0.02,
                size: Math.random() * 8 + 12,
                shape: shapes[Math.floor(Math.random() * shapes.length)],
                opacity: Math.random() * 0.08 + 0.02,
                color: colors[Math.floor(Math.random() * colors.length)]
            });
        }
    }

    function drawPiece(p) {
        ctx.save();
        ctx.translate(p.x, p.y);
        ctx.rotate(p.rotation);
        ctx.fillStyle = `rgba(${p.color}, ${p.opacity})`;
        ctx.strokeStyle = `rgba(${p.color}, ${p.opacity * 1.5})`;
        p.shape.forEach(block => {
            const bx = block[0] * p.size;
            const by = block[1] * p.size;
            ctx.fillRect(bx, by, p.size - 1, p.size - 1);
            ctx.strokeRect(bx, by, p.size - 1, p.size - 1);
        });
        ctx.restore();
    }

    function animate() {
        ctx.clearRect(0, 0, width, height);
        pieces.forEach(p => {
            drawPiece(p);
            p.y += p.speed;
            p.rotation += p.rotSpeed;
            if (p.y > height + 50) {
                p.y = -50;
                p.x = Math.random() * width;
            }
        });
        requestAnimationFrame(animate);
    }

    window.addEventListener('resize', init);
    init();
    animate();
})();