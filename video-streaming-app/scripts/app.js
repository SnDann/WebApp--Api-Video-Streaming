document.addEventListener('DOMContentLoaded', function() {
    fetch('https://api.example.com/videos')
        .then(response => response.json())
        .then(data => {
            const container = document.getElementById('video-container');
            data.videos.forEach(video => {
                const card = document.createElement('div');
                card.className = 'video-card';
                card.innerHTML = `
                    <img src="${video.thumbnail}" alt="${video.title}" class="thumbnail">
                    <h3 class="title">${video.title}</h3>
                    <p class="description">${video.description}</p>
                    <button class="watch-button">Watch Now</button>
                `;
                container.appendChild(card);
            });
        })
        .catch(error => console.error('Error fetching videos:', error));
});