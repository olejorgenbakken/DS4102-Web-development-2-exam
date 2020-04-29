<template>
  <section class="card finished">
    <svg
      aria-hidden="true"
      focusable="false"
      data-prefix="fas"
      data-icon="shipping-fast"
      role="img"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 640 512"
      class="finished-icon"
    >
      <path
        :fill="colors.logo"
        d="M624 352h-16V243.9c0-12.7-5.1-24.9-14.1-33.9L494 110.1c-9-9-21.2-14.1-33.9-14.1H416V48c0-26.5-21.5-48-48-48H112C85.5 0 64 21.5 64 48v48H8c-4.4 0-8 3.6-8 8v16c0 4.4 3.6 8 8 8h272c4.4 0 8 3.6 8 8v16c0 4.4-3.6 8-8 8H40c-4.4 0-8 3.6-8 8v16c0 4.4 3.6 8 8 8h208c4.4 0 8 3.6 8 8v16c0 4.4-3.6 8-8 8H8c-4.4 0-8 3.6-8 8v16c0 4.4 3.6 8 8 8h208c4.4 0 8 3.6 8 8v16c0 4.4-3.6 8-8 8H64v128c0 53 43 96 96 96s96-43 96-96h128c0 53 43 96 96 96s96-43 96-96h48c8.8 0 16-7.2 16-16v-32c0-8.8-7.2-16-16-16zM160 464c-26.5 0-48-21.5-48-48s21.5-48 48-48 48 21.5 48 48-21.5 48-48 48zm320 0c-26.5 0-48-21.5-48-48s21.5-48 48-48 48 21.5 48 48-21.5 48-48 48zm80-208H416V144h44.1l99.9 99.9V256z"
      />
    </svg>
    <h2 class="finished-title">Bestilling fullført!</h2>
    <router-link :to="{name: 'Homepage'}">Gå tilbake til hovedsiden</router-link>
  </section>
</template>

<script>
import axios from "axios";

export default {
  name: "FinishedOrder",
  data() {
    return {
      colors: null
    };
  },
  created() {
    let settingsURL = `https://localhost:5001/settings`;
    axios.get(settingsURL).then(response => {
      this.colors = response.data;
    });
  }
};
</script>

<style scoped>
.finished {
  min-height: 300px;
  height: 100%;
  display: flex;
  flex-direction: column;
  text-align: center;
  align-items: center;
  justify-content: center;
  padding: 20px 40px;
}

.finished-icon {
  width: 60px;
  opacity: 0.9;
}

.finished-title {
  margin: 30px 0 10px 0;
}

a {
  line-height: 1.5em;
}
</style>