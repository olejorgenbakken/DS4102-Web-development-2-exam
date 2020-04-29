<template>
  <section class="empty">
    <svg
      aria-hidden="true"
      focusable="false"
      data-prefix="fas"
      data-icon="grimace"
      role="img"
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 0 512 512"
      class="empty-icon"
    >
      <path
        :fill="colors.logo"
        d="M248 8C111 8 0 119 0 256s111 248 248 248 248-111 248-248S385 8 248 8zM144 400h-8c-17.7 0-32-14.3-32-32v-8h40v40zm0-56h-40v-8c0-17.7 14.3-32 32-32h8v40zm-8-136c0-17.7 14.3-32 32-32s32 14.3 32 32-14.3 32-32 32-32-14.3-32-32zm72 192h-48v-40h48v40zm0-56h-48v-40h48v40zm64 56h-48v-40h48v40zm0-56h-48v-40h48v40zm64 56h-48v-40h48v40zm0-56h-48v-40h48v40zm-8-104c-17.7 0-32-14.3-32-32s14.3-32 32-32 32 14.3 32 32-14.3 32-32 32zm64 128c0 17.7-14.3 32-32 32h-8v-40h40v8zm0-24h-40v-40h8c17.7 0 32 14.3 32 32v8z"
        class
      />
    </svg>

    <h2 class="empty-title">Du har ingenting i kurven</h2>
    <router-link :to="{name: 'Homepage'}">Gå tilbake og se om du finner noe du liker</router-link>
  </section>
</template>

<script>
import { store } from "../../store.js";
import axios from "axios";
export default {
  name: "NoItems",
  data() {
    return {
      colors: {}
    };
  },
  beforeMount() {
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
.empty {
  min-height: 300px;
  height: 100%;
  display: flex;
  flex-direction: column;
  text-align: center;
  align-items: center;
  justify-content: center;
  padding: 20px 40px;
  background: var(--footer);
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