desc 'default'
task :default => [:build]

desc 'build'
task :build do
  sh 'msbuild'
end

desc 'rebuild'
task :rebuild do
  sh 'msbuild /t:clean;rebuild'
end

desc 'run'
task :run do
  cd 'bin/debug'
  sh './recipes'
end
