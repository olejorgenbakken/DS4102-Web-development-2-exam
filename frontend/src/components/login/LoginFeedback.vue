<template>
  <article class="feedback">
    <p>{{msg}}</p>
  </article>
</template>

<script>
export default {
  name: "Feedback",
  props: {
    msg: String
  },
  updated() {
    this.$el.classList.add("open");
    setTimeout(() => {
      this.$el.classList.remove("open");
    }, 7000);
  }
};
</script>

<style scoped>
.feedback {
  width: 100%;
  background: rgb(180, 0, 0);
  color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  overflow: hidden;
  transition: 0.3s ease-in-out;
  height: 0px;
}

.feedback.open {
  height: auto;
  padding: 10px;
}
</style>