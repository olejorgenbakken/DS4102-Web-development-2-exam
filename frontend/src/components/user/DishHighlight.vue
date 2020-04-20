<template>
  <section
    class="dish-hero"
    :style="'background-image: url(https:localhost:5001/images/' + dish.photo + ')'"
    :dish="dish.id"
  >
    <section class="overlay" :style="`background: ${settings.color}; color: ${settings.text}`">
      <section class="content">
        <h2 class="title">
          {{dish.name}}
          <small>fra {{dish.price}}kr</small>
        </h2>

        <p>{{dish.description}}</p>

        <section class="links">
          <router-link :to="{ name: 'Details', params: {id: dish.id}}">
            <button
              class="more-button"
              :style="`border: 3px solid ${settings.text}; color: ${settings.text}`"
            >Les mer</button>
          </router-link>
          <BuyButton
            :id="dish.id"
            :style="`background: ${settings.text}; color: ${settings.color}`"
          ></BuyButton>
        </section>
      </section>
    </section>
  </section>
</template>

<script>
import axios from "axios";
import BuyButton from "./BuyButton";

export default {
  name: "DishHighlight",
  components: {
    BuyButton
  },
  data() {
    return {
      dish: {},
      settings: {}
    };
  },
  beforeMount() {
    let highlightedDish = "https://localhost:5001/api/dishes/highlighted/true";
    axios.get(highlightedDish).then(response => {
      if (response.status != 200) {
        let randomDish = "https://localhost:5001/api/dishes";
        axios.get(randomDish).then(response => {
          let rnd = Math.floor(Math.random() * response.data.length);
          this.dish = response.data[rnd];
        });
      }
      this.dish = response.data;
    });

    const settings = `https://localhost:5001/settings/1`;
    axios.get(settings).then(response => {
      this.settings = response.data;
    });
  }
};
</script>

<style scoped>
.dish-hero {
  height: 100%;
  width: 100%;
  max-width: 1200px;
  margin: 0 auto;
  background-size: cover;
  background-position: center center;
  display: flex;
  align-items: flex-end;
  position: relative;
}

.overlay {
  width: 100%;
  clip-path: polygon(0 0, 100% 10%, 100% 100%, 0% 100%);
  padding: 30px;
}

.content {
  display: grid;
  gap: 10px;
}

.content h2,
.content button {
  font-family: var(--heading);
}

.content h2 {
  font-size: 2em;
  font-weight: 700;
}

.links {
  display: grid;
  grid-template-columns: max-content 100px;
  gap: 15px;
}

button {
  width: 100%;
  max-width: 150px;
  padding: 10px 30px;
  font-weight: 700;
  border-radius: 30px;
  transition: 0.2s ease-in-out;
}

.buy-button {
  background: white;
  color: black;
}

.more-button {
  background: transparent;
}

@media only screen and (min-width: 700px) {
  .dish-hero {
    overflow: hidden;
  }
  .overlay {
    position: relative;
    width: 60%;
    height: 100%;
    clip-path: polygon(0 0, 90% 0, 100% 100%, 0% 100%);
    display: flex;
    justify-content: center;
    align-items: center;
  }

  .content {
    padding-right: 20px;
  }

  .content button {
    margin-top: 20px;
  }
}

@media only screen and (min-width: 1200px) {
  .dish-hero {
    width: 95%;

    border-radius: 20px;
  }
}
</style>