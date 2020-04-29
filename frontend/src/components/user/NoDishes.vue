<template>
  <article class="no-dishes">
    <svg
      v-if="$route.name != 'Admin'"
      aria-hidden="true"
      focusable="false"
      data-prefix="fas"
      data-icon="sad-cry"
      role="img"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 496 512"
      class="empty-icon"
    >
      <path
        :fill="colors.logo"
        d="M248 8C111 8 0 119 0 256c0 90.1 48.2 168.7 120 212.1V288c0-8.8 7.2-16 16-16s16 7.2 16 16v196.7c29.5 12.4 62 19.3 96 19.3s66.5-6.9 96-19.3V288c0-8.8 7.2-16 16-16s16 7.2 16 16v180.1C447.8 424.7 496 346 496 256 496 119 385 8 248 8zm-65.5 216.5c-14.8-13.2-46.2-13.2-61 0L112 233c-3.8 3.3-9.3 4-13.7 1.6-4.4-2.4-6.9-7.4-6.1-12.4 4-25.2 34.2-42.1 59.9-42.1S208 197 212 222.2c.8 5-1.7 10-6.1 12.4-5.8 3.1-11.2.7-13.7-1.6l-9.7-8.5zM248 416c-26.5 0-48-28.7-48-64s21.5-64 48-64 48 28.7 48 64-21.5 64-48 64zm149.8-181.5c-5.8 3.1-11.2.7-13.7-1.6l-9.5-8.5c-14.8-13.2-46.2-13.2-61 0L304 233c-3.8 3.3-9.3 4-13.7 1.6-4.4-2.4-6.9-7.4-6.1-12.4 4-25.2 34.2-42.1 59.9-42.1S400 197 404 222.2c.6 4.9-1.8 9.9-6.2 12.3z"
        class
      />
    </svg>

    <svg
      v-else
      aria-hidden="true"
      focusable="false"
      data-prefix="fas"
      data-icon="database"
      role="img"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 448 512"
      class="empty-icon"
    >
      <path
        :fill="colors.logo"
        d="M448 73.143v45.714C448 159.143 347.667 192 224 192S0 159.143 0 118.857V73.143C0 32.857 100.333 0 224 0s224 32.857 224 73.143zM448 176v102.857C448 319.143 347.667 352 224 352S0 319.143 0 278.857V176c48.125 33.143 136.208 48.572 224 48.572S399.874 209.143 448 176zm0 160v102.857C448 479.143 347.667 512 224 512S0 479.143 0 438.857V336c48.125 33.143 136.208 48.572 224 48.572S399.874 369.143 448 336z"
        class
      />
    </svg>
    <h3 class="no-dishes-title">
      <label v-if="$route.name != 'Admin'">
        Det ser ut som vi ikke har det du leter etter,
        <br />men prøv gjerne et annet søk.
      </label>
      <label v-else>Begynn med å legge til en rett ovenfor</label>
    </h3>
  </article>
</template>

<script>
import { store } from "../../store.js";
import axios from "axios";

export default {
  name: "NoDishes",
  data() {
    return {
      colors: {}
    };
  },
  beforeCreate() {
    let settingsURL = `https://localhost:5001/settings`;
    axios.get(settingsURL).then(response => {
      if (response.status > 200) {
        this.colors = {
          logo: store.state.colors.logo,
          highlighted: store.state.colors.highlighted,
          highlightedText: store.state.colors.highlightedText
        };
      } else {
        this.colors = response.data;
      }
    });
  }
};
</script>

<style scoped>
.no-dishes {
  display: flex;
  flex-direction: column;
  text-align: center;
  align-items: center;
  justify-content: center;
  padding: 100px 40px;
  background: var(--footer);
}

.empty-icon {
  width: 60px;
  opacity: 0.9;
}

.no-dishes-title {
  font-weight: 500;
  margin: 30px 0 10px 0;
}
</style>