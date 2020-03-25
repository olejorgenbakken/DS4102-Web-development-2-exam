<template>
  <footer class="footer">
    <section class="content">
      <h2 class="footer-title">SUSHI Restaurant</h2>
    </section>
  </footer>
</template>

<script>
export default {
  name: "Introduction",
  props: {
    sitetitle: String
  }
};
</script>

<style scoped>
footer {
  margin: 60px auto 0 auto;
  height: 70vh;
  width: 100%;
  background: var(--black);
  color: white;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-start;
}

.footer-title {
  font-size: 2em;
  font-weight: 900;
}

.content {
  width: 100%;
  max-width: 1000px;
  margin: 0 auto;
  padding: 30px 30px 100px 30px;
}

@media only screen and (min-width: 600px) {
  .footer-title {
    font-size: 2.5em;
  }
}
</style>
