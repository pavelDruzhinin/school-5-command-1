<template>
  <v-app>
    <v-app-bar app>
      <v-toolbar-title class="headline text-uppercase">
        <router-link to="/" style="text-decoration: none; color: white">
          <span>HOME</span>
        </router-link>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <span><registration-form></registration-form></span>
    </v-app-bar>

    <v-content>
      <transition name="moveInUp">
      <router-view>
        <Index />
      </router-view>
      </transition>
    </v-content>

    <Footer />
  </v-app>
</template>


<script>
import Index from "./components/Index";
import Footer from "./components/Footer";
import RegistrationForm from "./components/RegistrationForm";


export default {
  name: "App",

  components: {
    Footer,
    Index,
    RegistrationForm

  },

  data: () => ({
    //
  })
};
</script>
<<<<<<< HEAD

=======
>>>>>>> 749b02e212da51c5590bff451f4fe8a99b1ab932
<style>
.moveInUp-enter-active{
animation: fadeIn 2s ease-in;
}
@keyframes fadeIn{
0%{
opacity: 0;
}
50%{
opacity: 0.5;
}
100%{
opacity: 1;
}
}
.moveInUp-leave-active{
animation: moveInUp .3s ease-in;
}
@keyframes moveInUp{
0%{
transform: translateY(0);
}
100%{
transform: translateY(-400px);
}
}
<<<<<<< HEAD
</style>
=======
</style>
>>>>>>> 749b02e212da51c5590bff451f4fe8a99b1ab932
