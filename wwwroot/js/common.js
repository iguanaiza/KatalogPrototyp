//karuzela ksiazek
window.scrollCarousel = (id, direction, loop = true) => {
    const wrapper = document.getElementById(id);
    if (!wrapper) return;

    const container = wrapper.querySelector('.carousel-container');
    if (!container) return;

    const card = container.querySelector('.book-card');
    if (!card) return;

    const cardWidth = card.offsetWidth + 24; //wartość odstępu (gap)
    const scrollAmount = cardWidth * 1;

    const newScroll = container.scrollLeft + (direction * scrollAmount);

    if (loop) {
        const maxScroll = container.scrollWidth - container.clientWidth;

        if (newScroll > maxScroll) {
            container.scrollTo({ left: 0, behavior: 'smooth' });
        } else if (newScroll < 0) {
            container.scrollTo({ left: maxScroll, behavior: 'smooth' });
        } else {
            container.scrollBy({ left: direction * scrollAmount, behavior: 'smooth' });
        }
    } else {
        container.scrollBy({ left: direction * scrollAmount, behavior: 'smooth' });
    }
};

//chat
document.addEventListener("DOMContentLoaded", () => {
    const toggleBtn = document.getElementById("chat-toggle-btn");
    const chatBox = document.getElementById("chat-box");
    const closeBtn = document.getElementById("chat-close-btn");
    const form = document.getElementById("chat-form");
    const input = document.getElementById("chat-input");
    const messages = document.getElementById("chat-messages");

    toggleBtn.addEventListener("click", () => {
        chatBox.classList.toggle("hidden");
        if (!chatBox.classList.contains("hidden")) {
            input.focus();
        }
    });

    closeBtn.addEventListener("click", () => {
        chatBox.classList.add("hidden");
    });

    form.addEventListener("submit", (e) => {
        e.preventDefault();
        const text = input.value.trim();
        if (!text) return;

        appendMessage("user", text);
        input.value = "";
        simulateBotResponse();
    });

    function appendMessage(sender, text) {
        const msg = document.createElement("div");
        msg.classList.add("chat-message", sender);
        msg.textContent = text;
        messages.appendChild(msg);
        messages.scrollTop = messages.scrollHeight;
    }

    function simulateBotResponse() {
        setTimeout(() => {
            appendMessage("bot", "To przykładowa odpowiedź. Jak mogę pomóc?");
        }, 600);
    }
});

