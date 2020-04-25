<template>
  <section class="wrapper" @keydown.esc="close">
    <section class="login">
      <section class="login-form card">
        <router-view></router-view>
      </section>
    </section>
  </section>
</template>

<script>
export default {
  name: "Login",
  created() {
    let body = document.querySelector("body");
    window.scrollTo(0, 0);
    body.style.height = "100vh";
    body.style.overflow = "hidden";
  },
  beforeDestroy() {
    let body = document.querySelector("body");
    body.style.height = "auto";
    body.style.overflow = "auto";
  },
  methods: {
    close() {
      this.$router.push({ name: "Homepage" });
    }
  }
};
</script>

<style scoped>
.wrapper {
  height: 100vh;
  width: 100%;
  position: absolute;
  top: 0;
  left: 0;
  z-index: 1;
  background: rgba(0, 0, 0, 0.7);
  overflow: hidden;
}

.login,
.create-user {
  cursor: default;
  position: relative;
  z-index: 2;
  height: 100%;
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  background-size: cover;
  background-position: center bottom;
}

.login-form {
  width: 80%;
  max-width: 350px;
  margin: 0 auto;
  padding: 20px;
}
</style>