<template>
  <section class="card empty">
    <svg
      aria-hidden="true"
      focusable="false"
      data-prefix="fas"
      data-icon="map-signs"
      role="img"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 512 512"
      class="empty-icon"
    >
      <path
        :fill="colors.logo"
        d="M507.31 84.69L464 41.37c-6-6-14.14-9.37-22.63-9.37H288V16c0-8.84-7.16-16-16-16h-32c-8.84 0-16 7.16-16 16v16H56c-13.25 0-24 10.75-24 24v80c0 13.25 10.75 24 24 24h385.37c8.49 0 16.62-3.37 22.63-9.37l43.31-43.31c6.25-6.26 6.25-16.38 0-22.63zM224 496c0 8.84 7.16 16 16 16h32c8.84 0 16-7.16 16-16V384h-64v112zm232-272H288v-32h-64v32H70.63c-8.49 0-16.62 3.37-22.63 9.37L4.69 276.69c-6.25 6.25-6.25 16.38 0 22.63L48 342.63c6 6 14.14 9.37 22.63 9.37H456c13.25 0 24-10.75 24-24v-80c0-13.25-10.75-24-24-24z"
        class
      />
    </svg>
    <h2 class="empty-title">Du har ingenting i kurven</h2>
    <router-link :to="{name: 'Homepage'}">Gå tilbake og se om du finner noe du liker</router-link>
  </section>
</template>

<script>
import axios from "axios";
export default {
  name: "NoItems",
  data() {
    return {
      colors: null
    };
  },
  created() {
    let settingsURL = `https://localhost:5001/settings/1`;
    axios.get(settingsURL).then(response => {
      this.colors = response.data;
    });
  }
};
</script>

<style scoped>
.empty {
  min-height: 300px;
  height: 100%;
  display: flex;
  flex-direction: column;
  text-align: center;
  align-items: center;
  justify-content: center;
  padding: 20px 40px;
}

.empty-icon {
  width: 60px;
  opacity: 0.9;
}

.empty-title {
  font-weight: 500;
  margin: 30px 0 10px 0;
}

a {
  line-height: 1.5em;
}
</style>