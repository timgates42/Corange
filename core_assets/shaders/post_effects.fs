
/* Headers */

vec3 unsharp_mask(sampler2D input, vec2 coords, float strength, int width, int height);

/* End */

vec3 unsharp_mask(sampler2D input, vec2 coords, float strength, int width, int height) {
  
  float off_x = 1.0 / float(width);
  float off_y = 1.0 / float(height);
  
  vec3 s0 = texture2D(input, coords + vec2(-off_x, off_y)).rgb;
  vec3 s1 = texture2D(input, coords + vec2(0.0, off_y)).rgb;
  vec3 s2 = texture2D(input, coords + vec2(off_x, off_y)).rgb;
  vec3 s3 = texture2D(input, coords + vec2(-off_x, 0.0)).rgb;
  vec3 s4 = texture2D(input, coords + vec2(0.0, 0.0)).rgb;
  vec3 s5 = texture2D(input, coords + vec2(off_x, 0.0)).rgb;
  vec3 s6 = texture2D(input, coords + vec2(-off_x, -off_y)).rgb;
  vec3 s7 = texture2D(input, coords + vec2(0.0, 0.0)).rgb;
  vec3 s8 = texture2D(input, coords + vec2(off_x, -off_y)).rgb;
  
  vec3 avg = (s0 + s1 + s2 + s3 + s5 + s6 + s7 + s8) / 8;
  
  vec3 diff = s4 - avg;
  return s4 + (diff * strength);
}